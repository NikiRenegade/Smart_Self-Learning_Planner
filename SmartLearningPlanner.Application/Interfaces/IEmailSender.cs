using System;

namespace SmartLearningPlanner.Application.Interfaces;

public interface IEmailSender
{
	Task SendEmailAsync(string email, string subject, string message);
}
