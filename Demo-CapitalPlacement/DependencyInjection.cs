using Demo_CapitalPlacement.Application.Common.Interfaces;
using Demo_CapitalPlacement.Domain.DataContext;
using Demo_CapitalPlacement.Infrastructure.CodeRepository;
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

            services.AddScoped<ICpCodeRepository, CpCodeRepository>();
            return services;
        }
    }
}
