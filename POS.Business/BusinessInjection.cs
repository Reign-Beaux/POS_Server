using Microsoft.Extensions.DependencyInjection;
using POS.Business.Areas;
using POS.Business.ArticlesTypes;
using POS.Business.Employess;
using POS.Business.Login;
using POS.Business.Roles;
using POS.Business.Selects;
using POS.Business.Users;
using POS.Data;

namespace POS.Business
{
  public static class BusinessInjection
  {
    public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
    {
      services.AddScoped<IAreasService, AreasService>();
      services.AddScoped<IArticlesTypesService, ArticlesTypesService>();
      services.AddScoped<IEmployeesService, EmployeeService>();
      services.AddScoped<ILoginService, LoginService>();
      services.AddScoped<IRolesService, RolesService>();
      services.AddScoped<ISelectsService, SelectService>();
      services.AddScoped<IUsersService, UsersService>();
      services.AddDataInjection();

      return services;
    }
  }
}
