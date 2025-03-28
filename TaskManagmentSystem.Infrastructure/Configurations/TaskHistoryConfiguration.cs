using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Domain.Entities;

namespace TaskManagmentSystem.Infrastructure.Configurations
{
	public partial class TaskHistoryConfiguration : IEntityTypeConfiguration<TaskHistoryEntity>
	{
		public void Configure(EntityTypeBuilder<TaskHistoryEntity> builder)
		{
			builder.HasKey(h => h.Id);

			builder.HasOne(h => h.Task)
				.WithMany(t => t.TaskHistories)
				.HasForeignKey(h => h.TaskId); 

			builder.HasOne(h => h.User)
				.WithMany(u => u.TaskHistories)
				.HasForeignKey(h => h.ChangedByUserId); 
		}
	}
}
