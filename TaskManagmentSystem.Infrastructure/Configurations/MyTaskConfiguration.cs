using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentSystem.Core.Domain.Entities;


namespace TaskManagmentSystem.Infrastructure.Configurations
{
    public class MyTaskConfiguration : IEntityTypeConfiguration<MyTaskEntity>
    {
        public void Configure(EntityTypeBuilder<MyTaskEntity> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);

            builder.
                HasOne(x => x.User);
        }
    }
}
