using Dapper;
using DapperParameters;
using POS.Common.Models;
using POS.Common.TableTypes;
using System.Data;

namespace POS.Data.Features
{
  public class FeaturesRepository : POSRepository, IFeaturesRepository
  {
        public FeaturesRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<Feature>> GetFeaturesByRole(int roleId)
    {
      string spString = "[dbo].[Usp_Features_CON_By_Role] @pi_RoleId";
      try
      {
        return (await _dbConnection.QueryAsync<Feature>(
          spString,
          new { pi_RoleId = roleId },
          transaction: _dbTransaction)).ToList();
      }
      catch (Exception ex)
      {
        throw new Exception("Error retrieving the Roles: " + ex.Message);
      }
    }

    //public async Task<List<Feature>> GetFeaturesByRole(List<int> ids)
    //{
    //  string spString = "[dbo].[Usp_Features_CON_By_Role]";
    //  var listIds = ids.Select(x => new IdsTT { Id = x });
    //  var parameters = new DynamicParameters();
    //  parameters.AddTable("@pt_Ids", "[dbo].[Ids_Type]", listIds);

    //  try
    //  {
    //    var response = (await _dbConnection.QueryAsync<Feature>(
    //      spString,
    //      parameters,
    //      commandType: CommandType.StoredProcedure,
    //      transaction: _dbTransaction));
    //    return response.ToList();
    //  }
    //  catch (Exception ex)
    //  {
    //    throw new Exception("Error retrieving the Roles: " + ex.Message);
    //  }
    //}
  }
}
