using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api_vertical.Data;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Shared.Dependencies
{
    public static class DbContextConfigurations
    {

        public static void DbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                // var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

    }
}