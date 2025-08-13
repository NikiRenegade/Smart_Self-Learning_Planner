using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Application.Services;

namespace SmartLearningPlanner.MobileApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authService;
	private readonly IUserService _userService;
	private readonly IJwtTokenService _jwtTokenService;

	public AuthController(IAuthService authService, IUserService userService, IJwtTokenService jwtTokenService)
	{
		_authService = authService;
		_userService = userService;
		_jwtTokenService = jwtTokenService;
	}

	[HttpPost("register")]
	public async Task<ActionResult> RegisterUser(RegisterUserDto registerUserDto)
	{
		bool userCreationResult = await _authService.RegisterUserAsync(registerUserDto);
		if (userCreationResult)
		{
			return CreatedAtAction(nameof(RegisterUser), new { email = registerUserDto.Email }, registerUserDto);
		}
		else
		{
			return BadRequest("Ошибка при регистрации пользователя.");
		}
	}

	[HttpPost("change-password")]
	public async Task<ActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
	{
		await _authService.ChangePasswordAsync(changePasswordDto);
		return NoContent();
	}

	[HttpGet("check-password")]
	public async Task<ActionResult> CheckPassword(string id, string password)
	{
		var result = await _authService.CheckPasswordAsync(id, password);
		return Ok(result);
	}

	[HttpGet("confirm-email")]
	public async Task<IActionResult> ConfirmEmail([FromQuery] string id, [FromQuery] string token)
	{
		await _authService.ConfirmEmailAsync(id, token);
		return Ok("Email успешно подтвержден!");
	}

	[HttpPost("login")]
	public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
	{

		if (await _userService.GetUserByEmailAsync(loginDto.Email) == null)
			return Unauthorized("Данный email не найден.");

		if (!await _authService.IsEmailConfirmedAsync(loginDto.Email))
			return Unauthorized("Пожалуйста, подтвердите свой email перед входом.");

		if (!await _authService.LoginAsync(loginDto))
			return Unauthorized("Неверный email или пароль.");

		var accessToken = await _jwtTokenService.GenerateJwtToken(loginDto.Email);
		var refreshToken = await _authService.UpdateRefreshTokenAsync(loginDto.Email);

		return Ok(new
		{
			AccessToken = accessToken,
			RefreshToken = refreshToken
		});
	}

	[Authorize]
	[HttpGet("validate-token")]
	public IActionResult ValidateToken()
	{
		var username = User.Identity?.Name ?? "Unknown";
		return Ok(new { message = "Token is valid", user = username });
	}

	[HttpPost("refresh-token")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
	{
		RefreshTokenUserDto refreshTokenDto;
		refreshTokenDto = await _authService.GetRefreshTokenUserDtoAsync(request.RefreshToken);

		if (refreshTokenDto == null || !refreshTokenDto.isValid)
			return Unauthorized();

		var accessToken = await _jwtTokenService.GenerateJwtToken(refreshTokenDto.Email);
		var refreshToken = await _authService.UpdateRefreshTokenAsync(refreshTokenDto.Email);

		return Ok(new
		{
			AccessToken = accessToken,
			RefreshToken = refreshToken
		});
	}





}
