using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Domain.Entities;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.Application.Services
{
	public class MyTaskService : IMyTaskService
	{
		private readonly IMyTaskRepository _myTaskRepository;
		private readonly ITaskHistoryService _taskHistoryService;
		public MyTaskService(IMyTaskRepository myTaskRepository, ITaskHistoryService taskHistoryService)
		{
			_myTaskRepository = myTaskRepository;
			_taskHistoryService = taskHistoryService;
		}

		public async Task CreateTask(MyTask task)
		{
			await _myTaskRepository.Create(task);
		}

		public async Task DeleteTask(Guid id)
		{
			await _myTaskRepository.Delete(id);
		}

		public async Task<MyTask> GetTaskById(Guid id)
		{
			return await _myTaskRepository.GetById(id);
		}

		public async Task<List<MyTask>> GetTasks()
		{
			return await _myTaskRepository.GetAll();
		}

		public async Task UpdateTask(MyTask oldTask, MyTask newTask, Guid userId)
		{
			if (oldTask == null || newTask == null)
			{
				throw new ArgumentNullException("Tasks cannot be null");
			}

			var properties = typeof(MyTask).GetProperties();

			foreach (var property in properties)
			{
				var oldValue = property.GetValue(oldTask)?.ToString();
				var newValue = property.GetValue(newTask)?.ToString();

				if (oldValue != newValue)
				{
					var taskHistory = TaskHistory.Create(
						Guid.NewGuid(), 
						property.Name,
						oldValue, 
						newValue, 
						DateTime.UtcNow, 
						userId,
						oldTask.Id
					);

					await _taskHistoryService.CreateTaskHistory(taskHistory);
				}
			}

			await _myTaskRepository.Update(newTask.Id, newTask.Name, newTask.Description, newTask.Status);
		}
	}
}
