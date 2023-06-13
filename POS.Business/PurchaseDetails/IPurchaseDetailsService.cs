using POS.Common.Models;
using POS.Common.TableTypes;

namespace POS.Business.PurchaseDetails
{
  public interface IPurchaseDetailsService
  {
    Task<POSTransactionResult> UpdatePurchaseDetail(int purchaseId, List<PurchaseDetail> details);
    Task<POSTransactionResult> TestMerge(int testNumber, List<IdsTT> ids);
  }
}
