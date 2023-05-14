using POS.Common.Models;

namespace POS.Data.Areas
{
  public interface IAreasRepository
  {
    Task<List<Area>> GetAreas();
    Task<Area> GetAreaById(int areaId);
    Task<int> PostArea(Area area);
    Task<int> UpdateArea(Area area);
    Task<int> DeleteArea(int areaId);
  }
}
