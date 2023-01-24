using Microsoft.EntityFrameworkCore;
using task.Data;
using task.Data.GameRepo;
using task.Helpers;

namespace task.Extentions
{
    public static class ApplicationServiceExtensions
    {
         public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseMySQL(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameRepository, GameRepository>();

           
            return services;
        }
    }
}