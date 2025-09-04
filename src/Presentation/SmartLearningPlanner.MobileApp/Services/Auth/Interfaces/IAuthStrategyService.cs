using System;

namespace SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;

public interface IAuthStrategyService
{
	Task<bool> LoginAsync();
}
