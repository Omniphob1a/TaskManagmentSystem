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
	public class MyTaskService : IMyTaskService
	{
		private readonly IMyTaskRepository _myTaskRepository;
		public MyTaskService(IMyTaskRepository myTaskRepository)
		{
			_myTaskRepository = myTaskRepository;
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

		public async Task UpdateTask(Guid id, string name, string description, string status)
		{
			await _myTaskRepository.Update(id, name, description, status);
		}
	}
}
