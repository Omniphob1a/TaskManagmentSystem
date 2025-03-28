using API.Extensions;
using LearningPlatform.Persistence.Mappings;
using Microsoft.AspNetCore.CookiePolicy;
using TaskManagmentSystem.Application;
using TaskManagmentSystem.Infrastructure;
using TaskManagmentSystem.Infrastructure.Authentication;
using Serilog;
using Hangfire;
using TaskManagmentSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.CreateLogger();
builder.Services.AddAntiforgery(options =>
{
	options.HeaderName = "X-CSRF-TOKEN"; // Опционально: кастомное имя заголовка
});
builder.Host.UseSerilog();

builder.Services.AddApiAuthentication(configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure(configuration);

builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

builder.Services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

builder.Services.AddAutoMapper(typeof(DataBaseMappings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.Strict,
	HttpOnly = HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.Always
});

app.UseHangfireDashboard("/mydashboard");

app.UseAuthentication();

app.UseAuthorization();

app.UseAntiforgery();

app.AddMappedEndpoints();

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider
		.GetRequiredService<TaskManagmentSystemContext>();
	dbContext.Database.Migrate();
}
app.Run();
