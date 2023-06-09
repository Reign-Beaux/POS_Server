﻿using Microsoft.Extensions.DependencyInjection;
using POS.Business.Areas;
using POS.Business.Articles;
using POS.Business.ArticlesTypes;
using POS.Business.Brands;
using POS.Business.Employess;
using POS.Business.Inventories;
using POS.Business.Login;
using POS.Business.PurchaseDetails;
using POS.Business.Purchases;
using POS.Business.Roles;
using POS.Business.Selects;
using POS.Business.Suppliers;
using POS.Business.Users;
using POS.Data;

namespace POS.Business
{
  public static class BusinessInjection
  {
    public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
    {
      services.AddScoped<IAreasService, AreasService>();
      services.AddScoped<IArticlesService, ArticlesService>();
      services.AddScoped<IArticlesTypesService, ArticlesTypesService>();
      services.AddScoped<IBrandsService, BrandsService>();
      services.AddScoped<IEmployeesService, EmployeeService>();
      services.AddScoped<IInventoriesService, InventoriesService>();
      services.AddScoped<ILoginService, LoginService>();
      services.AddScoped<IPurchasesService, PurchasesService>();
      services.AddScoped<IPurchaseDetailsService, PurchaseDetailsService>();
      services.AddScoped<IRolesService, RolesService>();
      services.AddScoped<ISelectsService, SelectService>();
      services.AddScoped<ISuppliersService, SuppliersService>();
      services.AddScoped<IUsersService, UsersService>();
      services.AddDataInjection();

      return services;
    }
  }
}
