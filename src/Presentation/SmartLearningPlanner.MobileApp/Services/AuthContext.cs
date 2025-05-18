using System;

namespace SmartLearningPlanner.MobileApp.Services;

public class AuthContext
{
	private IAuthStrategyService _strategy;
	public void SetStrategy(IAuthStrategyService strategy)
	{
		_strategy = strategy;
	}
	public async Task<bool> LoginAsync()
	{
		if (_strategy == null)
			throw new InvalidOperationException("Стратегия аутентификации пользователя не выбрана");

		return await _strategy.LoginAsync();
	}

}
