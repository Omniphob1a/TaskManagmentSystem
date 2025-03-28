using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
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
        private readonly IDistributedCache _cache;
		private readonly IMapper _mapper;
        public MyTaskRepository(TaskManagmentSystemContext context, IMapper mapper, IDistributedCache cache)
        {
            _context = context;
            _cache = cache; 
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
			await _context.SaveChangesAsync();
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
			var cacheKey = $"Task_{id}";

			// Пытаемся получить данные из кэша
			var cachedData = await _cache.GetStringAsync(cacheKey);

			if (!string.IsNullOrEmpty(cachedData))
			{
				return JsonSerializer.Deserialize<MyTask>(cachedData);
			}

			var myTaskEntity = await _context.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(task => task.Id == id) ?? throw new Exception();

            var result = _mapper.Map<MyTask>(myTaskEntity);

            await _cache.SetStringAsync(cacheKey,
                JsonSerializer.Serialize(result),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });

            return result;
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
