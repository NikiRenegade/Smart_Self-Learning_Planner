using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces;

public interface IJwtTokenService
{
	public Task<string> GenerateJwtToken(string email);
}
