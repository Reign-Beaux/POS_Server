using Microsoft.Extensions.Configuration;
using POS.Data.Areas;
using POS.Data.Articles;
using POS.Data.ArticleTypes;
using POS.Data.Brands;
using POS.Data.Employees;
using POS.Data.Features;
using POS.Data.Inventories;
using POS.Data.Login;
using POS.Data.Roles;
using POS.Data.Selects;
using POS.Data.Users;
using System.Data;
using System.Data.SqlClient;

namespace POS.Data.UnitsOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _dbConnection;
    private readonly IDbTransaction _dbTransaction;

    public IAreasRepository AreasRepository { get; }
    public IArticlesRepository ArticlesRepository { get; }
    public IArticlesTypesRepository ArticlesTypesRepository { get; }
    public IBrandsRepository BrandsRepository { get; }
    public IEmployeesRepository EmployeesRepository { get; }
    public IFeaturesRepository FeaturesRepository { get; }
    public IInventoriesRepository InventoriesRepository { get; }
    public ILoginRepository LoginRepository { get; }
    public IRolesRepository RolesRepository { get; }
    public ISelectsRepository SelectsRepository { get; }
    public IUsersRepository UsersRepository { get; }

    public UnitOfWork(IConfiguration configuration)
    {
      _configuration = configuration;
      _dbConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]!);
      _dbConnection.Open();
      _dbTransaction = _dbConnection.BeginTransaction();

      AreasRepository = new AreasRepository(_dbTransaction);
      ArticlesRepository = new ArticlesRepository(_dbTransaction);
      ArticlesTypesRepository = new ArticlesTypesRepository(_dbTransaction);
      BrandsRepository = new BrandsRepository(_dbTransaction);
      EmployeesRepository = new EmployeesRepository(_dbTransaction);
      FeaturesRepository = new FeaturesRepository(_dbTransaction);
      InventoriesRepository = new InventoriesRepository(_dbTransaction);
      LoginRepository = new LoginRepository(_dbTransaction);
      RolesRepository = new RolesRepository(_dbTransaction);
      SelectsRepository = new SelectsRepository(_dbTransaction);
      UsersRepository = new UsersRepository(_dbTransaction);
    }

    public void Commit()
    {
      try
      {
        _dbTransaction.Commit();
      }
      catch (Exception)
      {
        _dbTransaction.Rollback();
      }
      finally
      {
        _dbTransaction.Dispose();
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        _dbTransaction?.Dispose();
        _dbConnection?.Dispose();
      }
    }

    ~UnitOfWork()
    {
      Dispose(false);
    }
  }
}
