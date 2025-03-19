using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Domain.Models;
using TaskManagmentSystem.Infrastructure.Data;

namespace TaskManagmentSystem.Infrastructure.Repositories
{
    public class MyTaskRepository : IMyTaskRepository
    {
		private readonly TaskManagmentSystemContext _context;
		private readonly IMapper _mapper;
        public MyTaskRepository(TaskManagmentSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public async Task Create(MyTask myTask)
        {
            var taskEntity = new MyTaskEntity()
            {
                Id = myTask.Id,
                Name = myTask.Name,
                Description = myTask.Description,
                Status = myTask.Status
            };
			await _context.Tasks.AddAsync(taskEntity);
        }

        public async Task Delete(Guid id)
        {
            await _context.Tasks
                .Where(task => task.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<MyTask>> GetAll()
        {
			var myTaskEntities = await _context.Tasks
		        .AsNoTracking()
		        .ToListAsync();

			return _mapper.Map<List<MyTask>>(myTaskEntities);
		}

        public async Task<MyTask> GetById(Guid id)
        {
            var myTaskEntity = await _context.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(task => task.Id == id) ?? throw new Exception();

            return _mapper.Map<MyTask>(myTaskEntity);
        }

        public async Task Update(Guid id, string name, string description, string status)
        {
            await _context.Tasks
                .Where(task => task.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(task => task.Name, name)
                .SetProperty(task => task.Description, description)
                .SetProperty(task => task.Status, status));   
        }
    }
}
