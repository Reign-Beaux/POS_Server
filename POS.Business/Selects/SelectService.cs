using POS.Common.DTOs;
using POS.Data.UnitsOfWork;

namespace POS.Business.Selects
{
  public class SelectService : POSService, ISelectsService
  {
    public SelectService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<SelectDTO>> GetAreas()
      => await _unitOfWork.SelectsRepository.GetAreas();

    public async Task<List<SelectDTO>> GetArticlesTypes()
      => await _unitOfWork.SelectsRepository.GetArticlesTypes();

    public async Task<List<SelectDTO>> GetBrands()
      => await _unitOfWork.SelectsRepository.GetBrands();

    public async Task<List<SelectDTO>> GetEmployees()
      => await _unitOfWork.SelectsRepository.GetEmployees();

    public async Task<List<SelectDTO>> GetRoles()
      => await _unitOfWork.SelectsRepository.GetRoles();
  }
}
