using Dapper;
using DapperParameters;
using POS.Common.Models;
using POS.Common.TableTypes;
using System.Data;

namespace POS.Data.PurchaseDetails
{
  public class PurchaseDetailsRepository : POSRepository, IPurchaseDetailsRepository
  {
    public PurchaseDetailsRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task TestMerge(int testNumber, List<IdsTT> ids)
    {
      string spString = "[dbo].[Usp_TestMerge]";
      var list = ids.Select(x => new IdsTT {
        Id = x.Id,
        ToUpdate = x.ToUpdate
      });
      var parameters = new DynamicParameters();

      parameters.Add("@pi_TestNumber", testNumber);
      parameters.AddTable("@pt_TestNumber2", "[dbo].[Ids_Type]", list);

      try
      {
        await _dbConnection.QueryAsync(
          spString,
          parameters,
          commandType: CommandType.StoredProcedure,
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error: " + ex.Message);
      }
    }

    public async Task UpdatePurchaseDetail(int purchaseId, List<PurchaseDetail> details)
    {
      string spString = "EXECUTE [dbo].[Usp_PurchaseDetail_UPD]";
      var list = details.Select(x => new PurchaseDetail {
        Id = x.Id,
        PurchaseId = purchaseId,
        ArticleId = x.ArticleId,
        QuantitySold = x.QuantitySold,
        Price = x.Price,
        Subtotal = x.Subtotal,
        Taxes = x.Taxes,
        Total = x.Total
      });

      var parameters = new DynamicParameters();
      parameters.Add("@pi_PurchaseId", purchaseId);
      parameters.AddTable("@pt_PurchaseDetail", "[dbo].[PurchaseDetail_Type]", list);

      try
      {
        await _dbConnection.QueryAsync(spString, parameters, transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Area: " + ex.Message);
      }
    }
  }
}
