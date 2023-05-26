using POS.Data.Areas;
using POS.Data.Articles;
using POS.Data.ArticleTypes;
using POS.Data.Brands;
using POS.Data.Employees;
using POS.Data.Features;
using POS.Data.Inventories;
using POS.Data.Login;
using POS.Data.Purchases;
using POS.Data.Roles;
using POS.Data.Selects;
using POS.Data.Suppliers;
using POS.Data.Users;

namespace POS.Data.UnitsOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    public IAreasRepository AreasRepository { get; }
    public IArticlesRepository ArticlesRepository { get; }
    public IArticlesTypesRepository ArticlesTypesRepository { get; }
    public IBrandsRepository BrandsRepository { get; }
    public IEmployeesRepository EmployeesRepository { get; }
    public IFeaturesRepository FeaturesRepository { get; }
    public IInventoriesRepository InventoriesRepository { get; }
    public ILoginRepository LoginRepository { get; }
    public IPurchasesRepository PurchasesRepository { get; }
    public IRolesRepository RolesRepository { get; }
    public ISelectsRepository SelectsRepository { get; }
    public ISuppliersRepository SuppliersRepository { get; }
    public IUsersRepository UsersRepository { get; }
    public void Commit();
  }
}
