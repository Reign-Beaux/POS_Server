using POS.Common.Models;
using POS.Common.TableTypes;

namespace POS.Data.PurchaseDetails
{
  public interface IPurchaseDetailsRepository
  {
    Task UpdatePurchaseDetail(int purchaseId, List<PurchaseDetail> details);
    Task TestMerge(int testNumber, List<IdsTT> ids);
  }
}
