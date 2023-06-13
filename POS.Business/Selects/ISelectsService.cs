using POS.Common.DTOs;

namespace POS.Business.Selects
{
  public interface ISelectsService
  {
    Task<List<SelectDTO>> GetAreas();
    Task<List<SelectDTO>> GetArticles();
    Task<List<SelectDTO>> GetArticlesTypes();
    Task<List<SelectDTO>> GetBrands();
    Task<List<SelectDTO>> GetEmployees();
    Task<List<SelectDTO>> GetFeatures();
    Task<List<SelectDTO>> GetFeaturesByRole(int roleId);
    Task<List<SelectDTO>> GetRoles();
    Task<List<SelectDTO>> GetSuppliers();
    Task<List<SelectDTO>> GetUsers();
  }
}
