using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Business.Purchases
{
  public interface IPurchasesService
  {
    Task<List<PurchaseDTO>> GetPurchases();
    Task<Purchase> GetPurchaseById(int purchaseId);
    Task<POSTransactionResult> PostPurchase(PurchaseRequestDTO purchaseRequest);
    Task<POSTransactionResult> UpdatePurchase(PurchaseRequestDTO purchaseRequest);
    Task<POSTransactionResult> DeletePurchase(int purchaseId);
    Task<POSTransactionResult> UpdateStatus(int purchaseId, int status);
  }
}
