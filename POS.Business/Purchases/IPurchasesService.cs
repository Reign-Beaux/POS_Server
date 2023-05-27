using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Business.Purchases
{
  public interface IPurchasesService
  {
    Task<List<PurchaseDTO>> GetPurchases();
    Task<Purchase> GetPurchaseById(int purchaseId);
    Task<POSTransactionResult> PostPurchase(int supplierId, string userName);
    Task<POSTransactionResult> UpdatePurchase(Purchase purchase);
    Task<POSTransactionResult> DeletePurchase(int purchaseId);
  }
}
