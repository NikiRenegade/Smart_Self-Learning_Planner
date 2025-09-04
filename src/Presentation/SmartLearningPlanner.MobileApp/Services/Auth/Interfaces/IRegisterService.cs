using System;
using SmartLearningPlanner.MobileApp.Models;
namespace SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;

public interface IRegisterService
{
	Task<bool> RegisterAsync(string userName, string firstName, string lastName, string password, string email);
}
