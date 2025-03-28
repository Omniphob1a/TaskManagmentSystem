using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using TaskManagmentSystem.API.Contracts.MyTasks;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Application.Services;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.API.Endpoints
{
	public static class MailEndpoints
	{
		public static IEndpointRouteBuilder MapMailEndpoints(this IEndpointRouteBuilder app)
		{
			var endpoints = app.MapGroup("mail");

			endpoints.MapPost("{taskId:guid}", SendRemindMail);

			return endpoints;
		}

		public static async Task<IResult> SendRemindMail(
			[FromRoute] Guid taskId,
			[FromBody] ScheduleReminderRequest request,
			[FromServices] IRecurringJobManager recurringJobManager,
			[FromServices] MailService mailService,
			[FromServices] MyTaskService taskService,
			[FromServices] UsersService userService)
		{
			var user = await userService.GetUserByEmail(request.UserEmail);
			var task = await taskService.GetTaskById(taskId);

			if (user == null || task == null)
				return Results.NotFound();

			var job = new ReminderJob
			{
				TaskId = taskId,
				UserEmail = request.UserEmail,
				Message = request.Message ?? $"Не забудьте выполнить: {task.Name}",
				TaskName = task.Name,
				TaskDescription = task.Description
			};

			recurringJobManager.AddOrUpdate<IMailService>(
				$"reminder_{taskId}",
				service => service.SendReminderAsync(job),
				request.CronExpression);

			return Results.Ok();
		}
	}
}
