using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Application.Setting;
namespace SmartLearningPlanner.Application.Services;

public class EmailSender : IEmailSender
{
	private readonly EmailSettings _emailSettings;

	public EmailSender(IOptions<EmailSettings> emailSettings)
	{
		_emailSettings = emailSettings.Value;
	}

	public async Task SendEmailAsync(string email, string subject, string message)
	{
		using var client = new SmtpClient(_emailSettings.SmtpServer, (int)_emailSettings.Port)
		{
			Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
			EnableSsl = true
		};

		var mailMessage = new MailMessage
		{
			From = new MailAddress(_emailSettings.FromEmail),
			Subject = subject,
			Body = message,
			IsBodyHtml = true
		};

		mailMessage.To.Add(email);
		await client.SendMailAsync(mailMessage);
	}
}
