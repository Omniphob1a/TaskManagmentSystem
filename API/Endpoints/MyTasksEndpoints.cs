﻿using Microsoft.AspNetCore.Mvc;
using TaskManagmentSystem.API.Contracts.MyTasks;
using TaskManagmentSystem.Application.Services;
using TaskManagmentSystem.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using TaskManagmentSystem.Core.Enums;

namespace TaskManagmentSystem.API.Endpoints
{
	public static class MyTasksEndpoints
	{
		public static IEndpointRouteBuilder MapMyTasksEndpoints(this IEndpointRouteBuilder app)
		{
			var endpoints = app.MapGroup("myTask");

			endpoints.MapPost(string.Empty, CreateMyTask)
				.RequirePermissions(Permission.Create);

			endpoints.MapGet(string.Empty, GetMyTask)
				.RequirePermissions(Permission.Read);

			endpoints.MapGet("{id:guid}", GetMyTaskById)
				.RequirePermissions(Permission.Read);

			endpoints.MapPut("{id:guid}", UpdateMyTask)
				.RequirePermissions(Permission.Update);

			endpoints.MapDelete("{id:guid}", DeleteMyTask)
				.RequirePermissions(Permission.Delete);

			return endpoints;
		}
		public static async Task<IResult> CreateMyTask([FromBody] CreateMyTaskRequest request,
			HttpContext context,
			MyTaskService myTasksService)
		{
			var task = MyTask.Create(
				Guid.NewGuid(),
				request.Name,
				request.Description,
				request.Status
				);
			await myTasksService.CreateTask(task);

			return Results.Ok();
		}

		public static async Task<IResult> GetMyTask(
			HttpContext context,
			MyTaskService myTasksService)
		{
			var myTask = await myTasksService.GetTasks();

			var response = myTask
				.Select(task => new GetMyTaskResponse(task.Id, task.Name, task.Description, task.Status));
				
			return Results.Ok(response);
		}

		public static async Task<IResult> GetMyTaskById(
			[FromRoute] Guid id,
			HttpContext context,
			MyTaskService myTasksService)
		{
			var myTask = await myTasksService.GetTaskById(id);

			var response = new GetMyTaskResponse(id, myTask.Name, myTask.Description, myTask.Status);

			return Results.Ok(response);
		}

		public static async Task<IResult> UpdateMyTask(
			[FromRoute] Guid id,
			[FromBody] UpdateMyTaskRequest request,
			HttpContext context,
			MyTaskService myTasksService)
		{
			await myTasksService.UpdateTask(id, request.Name, request.Description, request.Status);

			return Results.Ok();
		}

		public static async Task<IResult> DeleteMyTask(
			[FromRoute] Guid id,
			MyTaskService myTasksService
			)
		{
			await myTasksService.DeleteTask(id);

			return Results.Ok();
		}
	}
}
