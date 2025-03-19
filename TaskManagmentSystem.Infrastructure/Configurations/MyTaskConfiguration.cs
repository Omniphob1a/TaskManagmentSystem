using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentSystem.Core.Domain.Entities;


namespace TaskManagmentSystem.Infrastructure.Configurations
{
    public class MyTaskConfiguration : IEntityTypeConfiguration<MyTaskEntity>
    {
        public void Configure(EntityTypeBuilder<MyTaskEntity> builder)
        {
			builder.HasKey(c => c.Id);
		}
    }
}
