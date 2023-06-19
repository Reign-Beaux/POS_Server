using POS.Common.DTOs;
using POS.Common.Models;
using POS.Common.TableTypes;

namespace POS.Business.PurchaseDetails
{
  public interface IPurchaseDetailsService
  {
    Task<List<PurchaseDetailDTO>> GetPurchaseDetails(int purchaseId);
    Task<PurchaseDetail> GetPurchaseDetailById(int purchaseDetailId);
    Task<POSTransactionResult> PostPurchaseDetail(PurchaseDetail purchaseDetail);
    Task<POSTransactionResult> UpdatePurchaseDetail(PurchaseDetail purchaseDetail);
    Task<POSTransactionResult> DeletePurchaseDetail(int purchaseDetailId);
  }
}
