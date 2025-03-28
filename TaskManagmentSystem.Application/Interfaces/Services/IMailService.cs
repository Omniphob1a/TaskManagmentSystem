using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MimeKit;
using TaskManagmentSystem.Domain.Models;
using Microsoft.AspNetCore.Http;
using MailKit.Net.Smtp;
using TaskManagmentSystem.Application.Interfaces.Models;

namespace TaskManagmentSystem.Application.Interfaces.Services
{
	public interface IMailService
	{
		Task SendReminderAsync(ReminderJob job);
	}
}
