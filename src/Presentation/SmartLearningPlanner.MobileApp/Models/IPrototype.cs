using System;

namespace SmartLearningPlanner.MobileApp.Models;

public interface IPrototype<T>
{
	T Clone();
}
