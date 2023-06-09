﻿using Dapper;
using POS.Common.DTOs;
using POS.Common.Models;
using System.Data;

namespace POS.Data.PurchaseDetails
{
  public class PurchaseDetailsRepository : POSRepository, IPurchaseDetailsRepository
  {
    public PurchaseDetailsRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<PurchaseDetailDTO>> GetPurchaseDetails(int purchaseId)
    {
      string spString = "[dbo].[Usp_PurchaseDetail_CON] @ps_QueryType, @pi_Id";
      return (await _dbConnection.QueryAsync<PurchaseDetailDTO>(
        spString,
        new
        {
          ps_QueryType = "byPurchase",
          pi_Id = purchaseId
        },
        transaction: _dbTransaction)).ToList();
    }

    public async Task<PurchaseDetail> GetPurchaseDetailById(int purchaseDetailId)
    {
      string spString = "[dbo].[Usp_PurchaseDetail_CON] @ps_QueryType, @pi_Id";
      return await _dbConnection.QuerySingleOrDefaultAsync<PurchaseDetail>(
        spString,
        new
        {
          ps_QueryType = "byId",
          pi_Id = purchaseDetailId
        },
        transaction: _dbTransaction);
    }

    public async Task<int> PostPurchaseDetail(PurchaseDetail purchaseDetail)
    {
      var spString =
        "[dbo].[Usp_PurchaseDetail_INS] @pi_PurchaseId, @pi_ArticleId, @pi_QuantitySold, @pd_Price, @pd_Subtotal, @pd_Taxes, @pd_Total";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            pi_PurchaseId = purchaseDetail.PurchaseId,
            pi_ArticleId = purchaseDetail.ArticleId,
            pi_QuantitySold = purchaseDetail.QuantitySold,
            pd_Price = purchaseDetail.Price,
            pd_Subtotal = purchaseDetail.Subtotal,
            pd_Taxes = purchaseDetail.Taxes,
            pd_Total = purchaseDetail.Total,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT PurchaseDetail: " + ex.Message);
      }
    }

    public async Task<int> UpdatePurchaseDetail(PurchaseDetail purchaseDetail)
    {
      string spString =
        "[dbo].[Usp_PurchaseDetail_UPD] @pi_PurchaseDetailId, @pi_PurchaseId, @pi_ArticleId, @pi_QuantitySold, @pd_Price, @pd_Subtotal, @pd_Taxes, @pd_Total";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_PurchaseDetailId = purchaseDetail.Id,
            pi_PurchaseId = purchaseDetail.PurchaseId,
            pi_ArticleId = purchaseDetail.ArticleId,
            pi_QuantitySold = purchaseDetail.QuantitySold,
            pd_Price = purchaseDetail.Price,
            pd_Subtotal = purchaseDetail.Subtotal,
            pd_Taxes = purchaseDetail.Taxes,
            pd_Total = purchaseDetail.Total,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE PurchaseDetail: " + ex.Message);
      }
    }

    public async Task<int> DeletePurchaseDetail(int purchaseDetailId)
    {
      string spString = "[dbo].[Usp_PurchaseDetail_DEL] @pi_PurchaseDetailId";
      try
      {
        return await _dbConnection.QueryFirstOrDefaultAsync<int>(
            spString,
            new { pi_PurchaseDetailId = purchaseDetailId },
            transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE PurchaseDetail: " + ex.Message);
      }
    }
  }
}
