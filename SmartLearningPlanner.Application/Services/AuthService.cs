using System;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;

namespace SmartLearningPlanner.Application.Services;

public class AuthService : IAuthService
{
	private readonly IAuthRepository _authRepository;
	private readonly IUserRepository _userRepository;
	private readonly IEmailSender _emailSender;

	public AuthService(IAuthRepository authRepository, IUserRepository userRepository, IEmailSender emailSender)
	{
		_authRepository = authRepository;
		_userRepository = userRepository;
		_emailSender = emailSender;
	}

	public async Task<bool> RegisterUserAsync(RegisterUserDto registerUserDto)
	{
		try
		{
			ApplicationUser user = new ApplicationUser
			{
				UserName = registerUserDto.UserName,
				FirstName = registerUserDto.FirstName,
				LastName = registerUserDto.LastName,
				Email = registerUserDto.Email
			};
			var token = await _authRepository.RegisterAsync(user, registerUserDto.Password);
			var confirmationLink = $"http://localhost:5188/api/auth/confirm-email?id={user.Id}&token={Uri.EscapeDataString(token)}";

			var message = $"<p>Здравствуйте, {user.UserName}!</p><p>Подтвердите ваш аккаунт по ссылке ниже <br> <a href='{confirmationLink}'>Подтвердить аккаунт</a>.</p>";
			await _emailSender.SendEmailAsync(user.Email, "Подтверждение аккаунта", message);
			return true;
		}
		catch
		{
			return false;
		}

	}
	public async Task ChangePasswordAsync(ChangePasswordDto changePasswordDto)
	{
		ApplicationUser user = await _userRepository.GetByIdAsync(changePasswordDto.Id);
		if (user == null) throw new Exception("User not found");
		await _authRepository.ChangePasswordAsync(user, changePasswordDto.Id, changePasswordDto.NewPassword);
	}

	public async Task<bool> CheckPasswordAsync(string id, string password)
	{
		ApplicationUser user = await _userRepository.GetByIdAsync(id);
		if (user == null) throw new Exception("User not found");

		return await _authRepository.CheckPasswordAsync(user, password);
	}

	public async Task ConfirmEmailAsync(string id, string token)
	{
		ApplicationUser user = await _userRepository.GetByIdAsync(id);
		if (user == null) throw new Exception("User not found");
		await _authRepository.ConfirmEmailAsync(id, token);
	}

	public async Task<bool> LoginAsync(LoginDto loginDto)
	{
		ApplicationUser user = await _userRepository.GetByEmailAsync(loginDto.Email);
		return await _authRepository.AuthenticateAsync(user, loginDto.Password);
	}

	public async Task<bool> IsEmailConfirmedAsync(string email)
	{
		ApplicationUser user = await _userRepository.GetByEmailAsync(email);
		return await _authRepository.IsEmailConfirmedAsync(user);
	}

	public async Task<AccessTokenUserDto> GetAccessTokenUserDtoAsync(string email)
	{
		var userId = _userRepository.GetUserIdByEmailAsync(email);
		return new AccessTokenUserDto
		{
			Id = await userId,
			Email = email
		};
	}

	public async Task<RefreshTokenUserDto> GetRefreshTokenUserDtoAsync(string refreshToken)
	{
		var user = await _authRepository.GetUserByRefreshTokenAsync(refreshToken);
		if (user != null)
		{
			return new RefreshTokenUserDto
			{
				Id = user?.Id,
				Email = user?.Email,
				RefreshToken = user?.RefreshToken,
				RefreshTokenExpiration = user.RefreshTokenExpiryTime,
				isValid = !(user == null || user?.RefreshTokenExpiryTime <= DateTime.UtcNow)
			};
		}
		else
		{
			return null;
		}
	}
	public async Task<string> UpdateRefreshTokenAsync(string email)
	{
		ApplicationUser user = await _userRepository.GetByEmailAsync(email);
		var refreshToken = Guid.NewGuid().ToString();
		await _authRepository.UpdateRefreshTokenAsync(user, refreshToken);
		return refreshToken;
	}

	public async Task<UserProfileDto> GetUserProfileAsync(string email)
	{
		var user = await _userRepository.GetByEmailAsync(email);
		if (user == null) throw new Exception("User not found");

		return new UserProfileDto
		{
			Id = user.Id,
			UserName = user.UserName,
			FirstName = user.FirstName,
			LastName = user.LastName,
			Email = user.Email
		};
	}
}
