using POS.Common.DTOs;
using POS.Data.UnitsOfWork;

namespace POS.Business.Selects
{
  public class SelectService : POSService, ISelectsService
  {
    public SelectService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<SelectDTO>> GetAreas()
      => await _unitOfWork.SelectsRepository.GetAreas();

    public async Task<List<SelectDTO>> GetArticles()
      => await _unitOfWork.SelectsRepository.GetArticles();

    public async Task<List<SelectDTO>> GetArticlesTypes()
      => await _unitOfWork.SelectsRepository.GetArticlesTypes();

    public async Task<List<SelectDTO>> GetBrands()
      => await _unitOfWork.SelectsRepository.GetBrands();

    public async Task<List<SelectDTO>> GetEmployees()
      => await _unitOfWork.SelectsRepository.GetEmployees();

    public async Task<List<SelectDTO>> GetFeatures()
      => await _unitOfWork.SelectsRepository.GetFeatures();

    public async Task<List<SelectDTO>> GetFeaturesByRole(int roleId)
    {
      var features = await _unitOfWork.FeaturesRepository.GetFeaturesByRole(roleId);
      var convertSelect = new List<SelectDTO>();
      foreach (var feature in features)
      {
        var convert = new SelectDTO();
        convert.Text = feature.Description;
        convert.Value = feature.Id;
        convertSelect.Add(convert);
      }

      return convertSelect;
    }

    public async Task<List<SelectDTO>> GetRoles()
      => await _unitOfWork.SelectsRepository.GetRoles();

    public async Task<List<SelectDTO>> GetSuppliers()
      => await _unitOfWork.SelectsRepository.GetSuppliers();

    public async Task<List<SelectDTO>> GetUsers()
      => await _unitOfWork.SelectsRepository.GetUsers();
  }
}
