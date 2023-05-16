using POS.Common.DTOs;

namespace POS.Data.Inventories
{
  public interface IInventoriesRepository
  {
    Task<List<InventoryDTO>> GetInventoryDetail();
  }
}
