using POS.Common.DTOs;

namespace POS.Business.Selects
{
  public interface ISelectsService
  {
    Task<List<SelectDTO>> GetAreas();
    Task<List<SelectDTO>> GetEmployees();
    Task<List<SelectDTO>> GetRoles();
  }
}
