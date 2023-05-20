using POS.Common.Models;

namespace POS.Data.Brands
{
  public interface IBrandsRepository
  {
    Task<List<Brand>> GetBrands();
    Task<Brand> GetBrandById(int brandId);
    Task<int> PostBrand(Brand brand);
    Task<int> UpdateBrand(Brand brand);
    Task<int> DeleteBrand(int brandId);
  }
}
