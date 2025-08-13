using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Application.Setting;
namespace SmartLearningPlanner.Infrastructure.Services;

public class jwtTokenService : IJwtTokenService
{
	private readonly JwtSettings _jwtSettings;
	private readonly IAuthService _authService;

	public jwtTokenService(IOptions<JwtSettings> jwtSettings, IAuthService authService)
	{
		_authService = authService;
		_jwtSettings = jwtSettings.Value;
	}

	public async Task<string> GenerateJwtToken(string email)
	{
		var userDto = await _authService.GetAccessTokenUserDtoAsync(email);
		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		var claims = new[]
				{
						new Claim(ClaimTypes.NameIdentifier, userDto.Id),
						new Claim(ClaimTypes.Email, userDto.Email),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
				};

		var token = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiresInMinutes),
				signingCredentials: credentials
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
