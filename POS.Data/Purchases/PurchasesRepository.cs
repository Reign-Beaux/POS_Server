using Dapper;
using POS.Common.DTOs;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Purchases
{
  public class PurchasesRepository : POSRepository, IPurchasesRepository
  {
    public PurchasesRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<PurchaseDTO>> GetPurchases()
    {
      string spString = "[dbo].[Usp_Purchases_CON]";
      return (await _dbConnection.QueryAsync<PurchaseDTO>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<Purchase> GetPurchaseById(int purchaseId)
    {
      string spString = "[dbo].[Usp_Purchases_CON] @pi_PurchaseId";
      var response = (await _dbConnection.QueryAsync<Purchase>(
        spString,
        new { pi_PurchaseId = purchaseId },
        transaction: _dbTransaction)).ToList();
      return response.FirstOrDefault();
    }

    public async Task<int> PostPurchase(int supplierId, string userName)
    {
      var spString = "[dbo].[Usp_Purchases_INS] @pi_SupplierId, @pi_Username";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            pi_SupplierId = supplierId,
            pi_Username = userName,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Purchase: " + ex.Message);
      }
    }

    public async Task<int> UpdatePurchase(Purchase purchase)
    {
      string spString = "[dbo].[Usp_Purchases_UPD] @pi_PurchaseId, @pi_SupplierId, @pi_UserId, @pd_Subtotal, @pd_Taxes, @pd_Total, @pdt_OrderDate";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_PurchaseId = purchase.Id,
            pi_UserId = purchase.UserId,
            pd_Subtotal = purchase.Subtotal,
            pd_Taxes = purchase.Taxes,
            pd_Total = purchase.Total,
            pdt_OrderDate = purchase.OrderDate,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE Purchase: " + ex.Message);
      }
    }

    public async Task<int> DeletePurchase(int purchaseId)
    {
      string spString = "[dbo].[Usp_Purchases_DEL] @pi_PurchaseId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_PurchaseId = purchaseId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Purchase: " + ex.Message);
      }
    }
  }
}
