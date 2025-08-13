using System;
using SmartLearningPlanner.MobileApp.Models;
namespace SmartLearningPlanner.MobileApp.Services;

public interface IRegisterService
{
	Task<bool> RegisterAsync(string userName, string firstName, string lastName, string password, string email);
}
