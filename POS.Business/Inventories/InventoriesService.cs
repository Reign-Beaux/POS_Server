using POS.Business.Inventories;
using POS.Common.DTOs;
using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Inventories
{
  public class InventoriesService : POSService, IInventoriesService
  {
    public InventoriesService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<InventoryDTO>> GetInventoryDetail()
      => await _unitOfWork.InventoriesRepository.GetInventoryDetail();
  }
}
