using POS.Common.Models;

namespace POS.Data.PurchaseDetails
{
  public interface IPurchaseDetailsRepository
  {
    Task<List<PurchaseDetail>> GetPurchaseDetails(int purchaseId);
    Task<PurchaseDetail> GetPurchaseDetailById(int purchaseDetailId);
    Task<int> PostPurchaseDetail(PurchaseDetail purchaseDetail);
    Task<int> UpdatePurchaseDetail(PurchaseDetail purchaseDetail);
    Task<int> DeletePurchaseDetail(int purchaseDetailId);
  }
}
