using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Core.Domain.Entities;

namespace TaskManagmentSystem.Infrastructure.Repositories
{
    internal class MyTaskRepository : IMyTaskRepository
    {
        public Task Create(MyTaskEntity myTask)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MyTaskEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MyTaskEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, string Name, string Description, string Status)
        {
            throw new NotImplementedException();
        }
    }
}
