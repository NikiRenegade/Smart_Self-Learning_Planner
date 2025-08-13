using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;
using SmartLearningPlanner.Infrastructure.EntityFramework;

namespace SmartLearningPlanner.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;

	public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public async Task<bool> AuthenticateAsync(ApplicationUser user, string password)
	{
		var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
		return result.Succeeded;
	}

	public async Task ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
	{
		var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
		if (!result.Succeeded)
		{
			throw new Exception($"Failed to change password: {string.Join(", ", result.Errors.Select(e => e.Description))}");
		}
	}

	public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
	{
		return await _userManager.CheckPasswordAsync(user, password);
	}

	public async Task ConfirmEmailAsync(string id, string token)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user != null)
		{
			var result = await _userManager.ConfirmEmailAsync(user, token);
			if (!result.Succeeded)
				throw new Exception($"Email confirmation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
		}
	}

	public Task<ApplicationUser> GetUserByRefreshTokenAsync(string refreshToken)
	{
		return _userManager.Users
			.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
	}

	public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
	{
		return await _userManager.IsEmailConfirmedAsync(user);
	}

	public async Task<string> RegisterAsync(ApplicationUser user, string password)
	{
		var result = await _userManager.CreateAsync(user, password);
		if (!result.Succeeded)
		{
			throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
		}
		return await _userManager.GenerateEmailConfirmationTokenAsync(user);
	}
	public async Task UpdateRefreshTokenAsync(ApplicationUser user, string refreshToken)
	{
		user.RefreshToken = refreshToken;
		user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
		await _userManager.UpdateAsync(user);
	}

}
