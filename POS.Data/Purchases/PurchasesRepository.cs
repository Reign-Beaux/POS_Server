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
      return await _dbConnection.QuerySingleOrDefaultAsync<Purchase>(
        spString,
        new { pi_PurchaseId = purchaseId },
        transaction: _dbTransaction);
    }

    public async Task<int> PostPurchase(PurchaseRequestDTO purchaseRequest)
    {
      var spString = "[dbo].[Usp_Purchases_INS] @pi_SupplierId, @pi_Username";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            pi_SupplierId = purchaseRequest.SupplierId,
            pi_Username = purchaseRequest.UserName,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Purchase: " + ex.Message);
      }
    }

    public async Task<int> UpdatePurchase(PurchaseRequestDTO purchaseRequest)
    {
      string spString = "[dbo].[Usp_Purchases_UPD] @pi_PurchaseId, @pi_SupplierId, @pi_Username";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_PurchaseId = purchaseRequest.Id,
            pi_SupplierId = purchaseRequest.SupplierId,
            pi_Username = purchaseRequest.UserName,
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
