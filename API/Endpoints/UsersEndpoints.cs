using LearningPlatform.API.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Application.Services;

namespace API.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);

            app.MapPost("login", Login);
            return app;
        }

        private static async Task<IResult> Register(
            [FromBody] RegisterUserRequest request,
            UsersService usersService)
        {
            await usersService.Register(request.Email, request.UserName, request.Password);

            return Results.Ok();
        }

        private static async Task<IResult> Login(
            [FromBody] LoginUserRequest request,
            UsersService usersService,
            HttpContext context)
        {
            var token = await usersService.Login(request.Email, request.Password);

            context.Response.Cookies.Append("secretCookie", token);

            return Results.Ok(token);
        }
    }
}
 