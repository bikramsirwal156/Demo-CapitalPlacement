using Demo_CapitalPlacement.Domain.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Demo_CapitalPlacement

{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddMediatR(a => a.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddDbContext<DataContext>(options =>
             options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
