using API.Extensions;
using LearningPlatform.Persistence.Mappings;
using Microsoft.AspNetCore.CookiePolicy;
using TaskManagmentSystem.Application;
using TaskManagmentSystem.Infrastructure;
using TaskManagmentSystem.Infrastructure.Authentication;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; 
// Add services to the container.
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

app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.Strict,
	HttpOnly = HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();

app.UseAuthorization();

app.AddMappedEndpoints();

app.Run();
