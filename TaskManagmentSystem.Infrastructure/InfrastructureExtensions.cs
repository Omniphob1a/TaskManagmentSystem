using LearningPlatform.Application.Auth;
using LearninPlatform.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Auth;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Infrastructure.Data;
using TaskManagmentSystem.Infrastructure.Repositories;

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
            services.AddScoped<IMyTaskRepository, MyTaskRepository>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }

    }
}
