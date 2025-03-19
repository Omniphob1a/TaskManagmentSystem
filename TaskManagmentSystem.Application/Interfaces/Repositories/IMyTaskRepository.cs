using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Domain.Models;

namespace TaskManagmentSystem.Application.Interfaces.Repositories
{
    public interface IMyTaskRepository
    {
        Task Create(MyTask myTask);
        Task<MyTask> GetById(Guid id);
        Task<List<MyTask>> GetAll();
        Task Update(Guid id, string Name, string Description, string Status);
        Task Delete(Guid id);
    }
}
