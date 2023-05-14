using Dapper;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Areas
{
  public class AreasRepository : POSRepository, IAreasRepository
  {
    public AreasRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<Area>> GetAreas()
    {
      string spString = "[dbo].[Usp_Areas_CON]";
      return (await _dbConnection.QueryAsync<Area>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<Area> GetAreaById(int areaId)
    {
      string spString = "[dbo].[Usp_Areas_CON] @pi_AreaId";
      var response = (await _dbConnection.QueryAsync<Area>(
        spString,
        new { pi_AreaId = areaId },
        transaction: _dbTransaction)).ToList();
      return response.FirstOrDefault();
    }

    public async Task<int> PostArea(Area area)
    {
      var spString = "[dbo].[Usp_Areas_INS] @ps_Code, @ps_Description";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            ps_Code = area.Code,
            ps_Description = area.Description,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Area: " + ex.Message);
      }
    }

    public async Task<int> UpdateArea(Area area)
    {
      string spString = "[dbo].[Usp_Areas_UPD] @pi_AreaId, @ps_Code, @ps_Description";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_AreaId = area.Id,
            ps_Code = area.Code,
            ps_Description = area.Description,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE Area: " + ex.Message);
      }
    }

    public async Task<int> DeleteArea(int areaId)
    {
      string spString = "[dbo].[Usp_Areas_DEL] @pi_AreaId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_AreaId = areaId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Area: " + ex.Message);
      }
    }
  }
}
