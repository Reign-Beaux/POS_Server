using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Areas
{
  public class AreasService : POSService, IAreasService
  {
    public AreasService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<Area>> GetAreas()
      => await _unitOfWork.AreasRepository.GetAreas();

    public async Task<Area> GetAreaById(int areaId)
      => await _unitOfWork.AreasRepository.GetAreaById(areaId);

    public async Task<POSTransactionResult> PostArea(Area area)
    {
      var idResult = await _unitOfWork.AreasRepository.PostArea(area);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdateArea(Area area)
    {
      var response = await _unitOfWork.AreasRepository.UpdateArea(area);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeleteArea(int areaId)
    {
      var response = await _unitOfWork.AreasRepository.DeleteArea(areaId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
