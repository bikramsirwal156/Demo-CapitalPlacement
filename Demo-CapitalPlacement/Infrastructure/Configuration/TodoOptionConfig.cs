using Demo_CapitalPlacement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_CapitalPlacement.Infrastructure.Configuration
{
    public class TodoOptionConfig : IEntityTypeConfiguration<TodoOptions>
    {
        public void Configure(EntityTypeBuilder<TodoOptions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(x => x.TodoItemId).IsRequired().HasColumnType("int");
            builder.Property(x => x.OptionName).IsRequired().HasColumnType("nvarchar");
        }
    }
}