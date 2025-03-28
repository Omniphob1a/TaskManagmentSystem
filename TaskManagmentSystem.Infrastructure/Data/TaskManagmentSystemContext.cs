using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Domain.Entities;
using TaskManagmentSystem.Domain.Models;
using TaskManagmentSystem.Infrastructure.Configurations;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public class TaskManagmentSystemContext(DbContextOptions<TaskManagmentSystemContext> options,
    IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
        public DbSet<MyTaskEntity> Tasks { get; set; }
        public DbSet<TaskHistoryEntity> TaskHistories { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagmentSystemContext).Assembly);
			modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
		}
    }
}
