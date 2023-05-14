using Microsoft.Extensions.DependencyInjection;
using POS.Data.UnitsOfWork;

namespace POS.Data
{
    public static class DataInjection
  {
    public static IServiceCollection AddDataInjection(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
  }
}
