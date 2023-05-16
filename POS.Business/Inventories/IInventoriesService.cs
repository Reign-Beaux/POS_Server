using POS.Common.DTOs;

namespace POS.Business.Inventories
{
  public interface IInventoriesService
  {
    Task<List<InventoryDTO>> GetInventoryDetail();
  }
}
