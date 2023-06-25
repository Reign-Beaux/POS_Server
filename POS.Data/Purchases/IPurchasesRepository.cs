using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Data.Purchases
{
  public interface IPurchasesRepository
  {
    Task<List<PurchaseDTO>> GetPurchases();
    Task<Purchase> GetPurchaseById(int purchaseId);
    Task<int> PostPurchase(PurchaseRequestDTO purchaseRequest);
    Task<int> UpdatePurchase(PurchaseRequestDTO purchaseRequest);
    Task<int> DeletePurchase(int purchaseId);
    Task<int> CalculateAmount(int purchaseId);
  }
}
