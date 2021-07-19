using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonDirectory.Domain.Interfaces;
using PersonDirectory.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Persistence
{
    public static class ServiceCollectionExtension
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("SQL"),
                      b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.BuildServiceProvider().GetRequiredService<IApplicationDbContext>().Database.Migrate();

        }
    }
}
