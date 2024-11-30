using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ambev.DeveloperEvaluation.ORM
{
    public static class DatabaseInitializer
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services)
        {
            try
            {
                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;

                if (!string.IsNullOrEmpty(environment))
                {
                    bool isDevelopment = environment.Equals("Development") || environment.Equals(Environments.Development);

                    if (isDevelopment)
                    {
                        using var scope = services.BuildServiceProvider().CreateScope();
                        var db = scope.ServiceProvider.GetRequiredService<DefaultContext>();
                        db.Database.Migrate();
                    }
                }

                return services;
            }
            catch (Exception)
            {
                return services;
            }
        }
    }
}
