using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.Application.Interfaces.Services
{
	public interface ITaskHistoryService
	{
		Task CreateTaskHistory(TaskHistory task);
		Task DeleteTaskHistory(Guid id);
		Task<TaskHistory> GetTaskHistoryById(Guid id);
		Task<List<TaskHistory>> GetTaskHistories();
		Task UpdateTaskHistory(Guid id, string fieldName, string oldValue, string newValue, DateTime? changeDate);
	}
}
