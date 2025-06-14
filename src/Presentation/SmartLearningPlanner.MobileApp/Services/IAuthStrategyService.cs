using System;

namespace SmartLearningPlanner.MobileApp.Services;

public interface IAuthStrategyService
{
	Task<bool> LoginAsync();
}
