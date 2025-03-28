using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Application.Interfaces.Repositories;
using TaskManagmentSystem.Domain.Entities;
using TaskManagmentSystem.Domain.Models;
using TaskManagmentSystem.Infrastructure.Data;

namespace TaskManagmentSystem.Infrastructure.Repositories
{
	internal class TaskHistoryRepository : ITaskHistoryRepository
	{
		private readonly TaskManagmentSystemContext _context;
		private readonly IMapper _mapper;

		public TaskHistoryRepository(TaskManagmentSystemContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task Create(TaskHistory taskHistory)
		{
			var taskHistoryEntity = new TaskHistoryEntity()
			{
				Id = taskHistory.Id,
				FieldName = taskHistory.FieldName,
				OldValue = taskHistory.OldValue,
				NewValue = taskHistory.NewValue,
				ChangeDate = taskHistory.ChangeDate,
				ChangedByUserId = taskHistory.ChangedByUserId,
				TaskId = taskHistory.TaskId
			};

			await _context.TaskHistories.AddAsync(taskHistoryEntity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			await _context.TaskHistories
				.Where(h => h.Id == id)
				.ExecuteDeleteAsync();
		}

		public async Task<List<TaskHistory>> GetAll()
		{
			var taskHistoriesEntities = await _context.TaskHistories
				.AsNoTracking()
				.ToListAsync();

			return _mapper.Map<List<TaskHistory>>(taskHistoriesEntities);
		}

		public async Task<TaskHistory> GetById(Guid id)
		{
			var taskHistoryEntity = await _context.TaskHistories
				.AsNoTracking()
				.FirstOrDefaultAsync(h => h.Id == id) ?? throw new Exception();

			return _mapper.Map<TaskHistory>(taskHistoryEntity);
		}

		public async Task Update(Guid id, string fieldName, string oldValue, string newValue, DateTime? changeDate)
		{
			await _context.TaskHistories
				.Where(h => h.Id == id)
				.ExecuteUpdateAsync(s => s
				.SetProperty(h => h.FieldName, fieldName)
				.SetProperty(h => h.OldValue, oldValue)
				.SetProperty(h => h.NewValue, newValue)
				.SetProperty(h => h.ChangeDate, changeDate)
				);
		}
	}
}
