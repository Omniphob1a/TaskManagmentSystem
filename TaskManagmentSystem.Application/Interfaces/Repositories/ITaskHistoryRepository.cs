using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.Application.Interfaces.Repositories
{
	public interface ITaskHistoryRepository
	{
		Task Create(TaskHistory taskHistory);
		Task<List<TaskHistory>> GetAll();
		Task<TaskHistory> GetById(Guid id);
		Task Update(Guid id, string fieldName, string oldValue, string newValue, DateTime? changeDate);
		Task Delete(Guid id);
	}
}
