using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.Application.Interfaces.Services
{
	public interface IMyTaskService
	{
		Task CreateTask(MyTask task);
		Task DeleteTask(Guid id);
		Task<MyTask> GetTaskById(Guid id);
		Task<List<MyTask>> GetTasks();
		Task UpdateTask(Guid id, string name, string description, string status);
	}
}
