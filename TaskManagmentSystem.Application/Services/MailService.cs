using Hangfire.Common;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Domain.Models;
using IMailService = TaskManagmentSystem.Application.Interfaces.Services.IMailService;

namespace TaskManagmentSystem.Application.Services
{
	public class MailService : IMailService
	{
		private readonly MailSettings _mailSettings;
		private readonly IWebHostEnvironment _env;
		public MailService(
		IOptions<MailSettings> mailSettings,
		IWebHostEnvironment env) // Внедряем IWebHostEnvironment
		{
			_mailSettings = mailSettings.Value;
			_env = env;
		}
		public async Task SendReminderAsync(ReminderJob job)
		{
			// Используем ContentRootPath для получения абсолютного пути
			var templatePath = Path.Combine(
				_env.ContentRootPath,
				"Templates",
				"RemindTemplate.html");

			if (!File.Exists(templatePath))
				throw new FileNotFoundException($"Template not found at: {templatePath}");

			string htmlTemplate = await File.ReadAllTextAsync(templatePath);

			var body = htmlTemplate
				.Replace("{{TaskName}}", job.TaskName)
				.Replace("{{TaskDescription}}", job.TaskDescription);

			var email = new MimeMessage
			{
				Sender = MailboxAddress.Parse(_mailSettings.Mail),
				Subject = $"Напоминание: Задача #{job.TaskName}",
				Body = new TextPart("html") { Text = body }
			};
			email.To.Add(MailboxAddress.Parse(job.UserEmail));

			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
			await smtp.SendAsync(email);
			await smtp.DisconnectAsync(true);
		}
	}
}
