using Demo_CapitalPlacement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo_CapitalPlacement.Domain.DataContext
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
       public DbSet<TodoItem> TodoItems {  get; set; }
       public DbSet<TodoOptions> TodoOptions {  get; set; }
    }
}
