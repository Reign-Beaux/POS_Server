using POS.Common.DTOs;

namespace POS.Data.Selects
{
  public interface ISelectsRepository {
    Task<List<SelectDTO>> GetAreas();
    Task<List<SelectDTO>> GetEmployees();
    Task<List<SelectDTO>> GetRoles();
  }
}
