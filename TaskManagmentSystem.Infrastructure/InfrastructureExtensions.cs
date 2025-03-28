using LearningPlatform.Application.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Auth;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Infrastructure.Authentication;
using TaskManagmentSystem.Infrastructure.Data;
using TaskManagmentSystem.Infrastructure.Repositories;
using TaskManagmentSystem.Domain.Models;
using Hangfire;
using Hangfire.PostgreSql;

namespace TaskManagmentSystem.Infrastructure
{
	public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagmentSystemContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(TaskManagmentSystemContext)))
            );
            services.AddScoped<IUsersRepository, UsersReporitory>();
            services.AddScoped<ITaskHistoryRepository, TaskHistoryRepository>();
            services.AddScoped<IMyTaskRepository, MyTaskRepository>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
			services.AddStackExchangeRedisCache(options =>
			{
				options.Configuration = configuration["Redis:ConnectionString"]!;
				options.InstanceName = configuration["Redis:InstanceName"]!;
			});
			services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddHangfire(x => x.UsePostgreSqlStorage(configuration.GetConnectionString(nameof(TaskManagmentSystemContext))));
			services.AddHangfireServer();
			services.AddControllers();
			return services;
        }

    }
}
