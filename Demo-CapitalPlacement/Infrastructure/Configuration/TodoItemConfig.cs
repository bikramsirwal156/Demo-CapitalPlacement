using Demo_CapitalPlacement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Demo_CapitalPlacement.Infrastructure.Configuration
{
    public class TodoItemConfig : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(t => t.Description).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsActive).IsRequired().HasColumnType("bit");
            builder.Property(t => t.RefrenceNumber).IsRequired().HasColumnType("nvarchar").HasMaxLength(3);
            builder.Property(t => t.ApplyDate).IsRequired().HasColumnType("datetime");
            builder.Property(t => t.Experience).IsRequired().HasColumnType("int");
        }
    }
}