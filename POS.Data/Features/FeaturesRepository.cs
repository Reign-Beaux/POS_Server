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
      return (await _dbConnection.QueryAsync<Feature>(
        spString,
        new { pi_RoleId = roleId },
        transaction: _dbTransaction)).ToList();
    }
  }
}
