﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Endpoints;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManagmentSystem.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Application.Services;
using TaskManagmentSystem.Core.Enums;
using TaskManagmentSystem.API.Endpoints;

namespace API.Extensions
{
    public static class ApiExtensions
    {

        public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
        {
			app.MapMyTasksEndpoints();
			app.MapUsersEndpoints();
			app.MapMailEndpoints();
        }

        public static void AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
					options.RequireHttpsMetadata = true;
					options.SaveToken = true;

					options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };
					options.Events = new JwtBearerEvents
					{
						OnMessageReceived = context =>
						{
							context.Token = context.Request.Cookies["secretCookie"];

							return Task.CompletedTask;
						}
					};
				});

			services.AddScoped<IPermissionService, PermissionService>();
			services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

			services.AddAuthorization();

		}

		public static IEndpointConventionBuilder RequirePermissions<TBuilder>(
		this TBuilder builder, params Permission[] permissions)
			where TBuilder : IEndpointConventionBuilder
		{
			return builder
				.RequireAuthorization(policy =>
					policy.AddRequirements(new PermissionRequirement(permissions)));
		}
	}
}
