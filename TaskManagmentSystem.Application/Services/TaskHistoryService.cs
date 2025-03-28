using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Application.Interfaces.Services;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.Application.Services
{
	internal class TaskHistoryService : ITaskHistoryService
	{
		private readonly ITaskHistoryRepository _taskHistoryRepository;

		public TaskHistoryService(ITaskHistoryRepository taskHistoryRepository)
		{
			_taskHistoryRepository = taskHistoryRepository;
		}

		public async Task CreateTaskHistory(TaskHistory task)
		{
			await _taskHistoryRepository.Create(task);
		}

		public async Task DeleteTaskHistory(Guid id)
		{
			await _taskHistoryRepository.Delete(id);
		}

		public async Task<List<TaskHistory>> GetTaskHistories()
		{
			return await _taskHistoryRepository.GetAll();
		}

		public async Task<TaskHistory> GetTaskHistoryById(Guid id)
		{
			return await _taskHistoryRepository.GetById(id);
		}

		public async Task UpdateTaskHistory(
			Guid id,
			string fieldName,
			string oldValue,
			string newValue,
			DateTime? changeDate)
		{
			await _taskHistoryRepository.Update(id, fieldName, oldValue, newValue, changeDate);
		}
	}
}
