#region "Libraries"

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MPIS.Device.Repository.Abstract;
using MPIS.Device.RepositoryModel;
using System;
using System.Linq;
using System.Reflection;

#endregion

namespace MPIS.Device.Repository.Configuration
{
    public static class  PersistenceExtension
    {
        public static void AddPersistenceService(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<Context>(options =>
            {
                var connectionString = Environment.GetEnvironmentVariable("AzureSQLConnectionString") ?? throw new InvalidOperationException("Can not found connection string.'");

                options.UseSqlServer(connectionString, contextOptionsBuilder =>
                {
                    contextOptionsBuilder.MigrationsHistoryTable("Migrations", "EF");
                    contextOptionsBuilder.MigrationsAssembly(Assembly.GetAssembly(typeof(Context)).FullName);
                });

                using (var context = new Context((DbContextOptions<Context>)options.Options))
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                        context.SaveChanges();
                    }
                }
            });

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IDeviceRepository, DeviceRepository>();
            builder.Services.AddTransient<IHardwareRepository, HardwareRepository>();
            builder.Services.AddTransient<ISoftwareRepository, SoftwareRepository>();
            builder.Services.AddTransient<IOperativeSystemRepository, OperativeSystemRepository>();
        }
    }
}
