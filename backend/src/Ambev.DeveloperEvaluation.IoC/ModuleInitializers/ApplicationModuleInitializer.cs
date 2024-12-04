using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ISaleService, SaleService>();
        builder.Services.AddScoped<ISaleManagerService, SaleManagerService>();
        builder.Services.AddScoped<IStockService, StockService>();
    }
}