using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Application.Services;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<UsersService>();
			services.AddScoped<ITaskHistoryService, TaskHistoryService>();
			services.AddScoped<MyTaskService>();
			services.AddScoped<MailService>(); // Регистрируем конкретный класс
			services.AddScoped<IMailService, MailService>(); // И интерфейс для Hangfire

			return services;
        }
    }
}
