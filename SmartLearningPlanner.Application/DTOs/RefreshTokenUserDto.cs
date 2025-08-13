using System;

namespace SmartLearningPlanner.Application.DTOs;

public class RefreshTokenUserDto
{
	public required string Id { get; set; }
	public required string Email { get; set; }
	public required string RefreshToken { get; set; }
	public required DateTime? RefreshTokenExpiration { get; set; }
	public bool isValid { get; set; }
}
