using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Brands
{
  public class BrandsService : POSService, IBrandsService
  {
    public BrandsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<Brand>> GetBrands()
      => await _unitOfWork.BrandsRepository.GetBrands();

    public async Task<Brand> GetBrandById(int brandId)
      => await _unitOfWork.BrandsRepository.GetBrandById(brandId);

    public async Task<POSTransactionResult> PostBrand(Brand brand)
    {
      var idResult = await _unitOfWork.BrandsRepository.PostBrand(brand);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdateBrand(Brand brand)
    {
      var response = await _unitOfWork.BrandsRepository.UpdateBrand(brand);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeleteBrand(int brandId)
    {
      var response = await _unitOfWork.BrandsRepository.DeleteBrand(brandId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
