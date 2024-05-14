using Microsoft.EntityFrameworkCore;

namespace Demo_CapitalPlacement.Domain.DataContext
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
    }
}
