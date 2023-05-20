using POS.Common.Models;

namespace POS.Business.Brands
{
  public interface IBrandsService
  {
    Task<List<Brand>> GetBrands();
    Task<Brand> GetBrandById(int brandId);
    Task<POSTransactionResult> PostBrand(Brand brand);
    Task<POSTransactionResult> DeleteBrand(int brandId);
    Task<POSTransactionResult> UpdateBrand(Brand brand);
  }
}
