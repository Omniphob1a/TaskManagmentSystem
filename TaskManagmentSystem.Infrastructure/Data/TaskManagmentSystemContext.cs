using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Domain.Entities;
using TaskManagmentSystem.Infrastructure.Configurations;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public class TaskManagmentSystemContext(DbContextOptions<TaskManagmentSystemContext> options,
    IOptions<AuthorizationOptions> authOptions, IConfiguration configuration) : DbContext(options)
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(nameof(TaskManagmentSystemContext)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MyTaskConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }
    }
}
