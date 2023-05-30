using POS.Common.DTOs;

namespace POS.Data.Selects
{
  public interface ISelectsRepository
  {
    Task<List<SelectDTO>> GetAreas();
    Task<List<SelectDTO>> GetArticles();
    Task<List<SelectDTO>> GetArticlesTypes();
    Task<List<SelectDTO>> GetBrands();
    Task<List<SelectDTO>> GetEmployees();
    Task<List<SelectDTO>> GetRoles();
    Task<List<SelectDTO>> GetSuppliers();
    Task<List<SelectDTO>> GetUsers();
  }
}
