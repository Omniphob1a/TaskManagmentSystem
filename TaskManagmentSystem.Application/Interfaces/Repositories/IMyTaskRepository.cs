using TaskManagmentSystem.Core.Domain.Entities;

namespace TaskManagmentSystem.Application.Interfaces.Repositories
{
    public interface IMyTaskRepository
    {
        Task Create(MyTaskEntity myTask);
        Task<MyTaskEntity> GetById(Guid id);
        Task<IEnumerable<MyTaskEntity>> GetAll();
        Task Update(Guid id, string Name, string Description, string Status);
        Task Delete(Guid id);
    }
}
