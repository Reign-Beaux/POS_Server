using Dapper;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Brands
{
  public class BrandsRepository : POSRepository, IBrandsRepository
  {
    public BrandsRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<Brand>> GetBrands()
    {
      string spString = "[dbo].[Usp_Brands_CON]";
      return (await _dbConnection.QueryAsync<Brand>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<Brand> GetBrandById(int brandId)
    {
      string spString = "[dbo].[Usp_Brands_CON] @pi_BrandId";
      var response = (await _dbConnection.QueryAsync<Brand>(
        spString,
        new { pi_BrandId = brandId },
        transaction: _dbTransaction)).ToList();
      return response.FirstOrDefault();
    }

    public async Task<int> PostBrand(Brand brand)
    {
      var spString = "[dbo].[Usp_Brands_INS] @ps_Code, @ps_Description";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            ps_Code = brand.Code,
            ps_Description = brand.Description,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Brand: " + ex.Message);
      }
    }

    public async Task<int> UpdateBrand(Brand brand)
    {
      string spString = "[dbo].[Usp_Brands_UPD] @pi_BrandId, @ps_Code, @ps_Description";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_BrandId = brand.Id,
            ps_Code = brand.Code,
            ps_Description = brand.Description,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE Brand: " + ex.Message);
      }
    }

    public async Task<int> DeleteBrand(int brandId)
    {
      string spString = "[dbo].[Usp_Brands_DEL] @pi_BrandId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_BrandId = brandId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Brand: " + ex.Message);
      }
    }
  }
}
