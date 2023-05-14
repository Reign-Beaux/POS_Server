using POS.Common.Models;

namespace POS.Business.Areas
{
  public interface IAreasService
  {
    Task<List<Area>> GetAreas();
    Task<Area> GetAreaById(int areaId);
    Task<POSTransactionResult> PostArea(Area area);
    Task<POSTransactionResult> DeleteArea(int areaId);
    Task<POSTransactionResult> UpdateArea(Area area);
  }
}
