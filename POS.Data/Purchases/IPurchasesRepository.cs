﻿using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Data.Purchases
{
  public interface IPurchasesRepository
  {
    Task<List<PurchaseDTO>> GetPurchases();
    Task<Purchase> GetPurchaseById(int purchaseId);
    Task<int> PostPurchase(Purchase purchase);
    Task<int> UpdatePurchase(Purchase purchase);
    Task<int> DeletePurchase(int purchaseId);
  }
}