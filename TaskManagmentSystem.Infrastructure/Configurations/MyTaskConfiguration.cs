using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentSystem.Core.Domain.Entities;


namespace TaskManagmentSystem.Infrastructure.Configurations
{
    public partial class MyTaskConfiguration : IEntityTypeConfiguration<MyTaskEntity>
    {
        public void Configure(EntityTypeBuilder<MyTaskEntity> builder)
        {
			builder.HasKey(t => t.Id);

            builder.HasMany(t => t.TaskHistories)
                .WithOne(h => h.Task)
                .HasForeignKey(h => h.TaskId);
		}
    }
}
