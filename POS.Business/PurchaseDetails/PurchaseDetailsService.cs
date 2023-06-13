using POS.Common.Models;
using POS.Common.TableTypes;
using POS.Data.UnitsOfWork;

namespace POS.Business.PurchaseDetails
{
  public class PurchaseDetailsService : POSService, IPurchaseDetailsService
  {
    public PurchaseDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<POSTransactionResult> UpdatePurchaseDetail(int purchaseId, List<PurchaseDetail> details)
    {
      await _unitOfWork.PurchaseDetailsRepository.UpdatePurchaseDetail(purchaseId, details);
      _unitOfWork.Commit();

      return new POSTransactionResult();
    }

    public async Task<POSTransactionResult> TestMerge(int testNumber, List<IdsTT> ids)
    {
      await _unitOfWork.PurchaseDetailsRepository.TestMerge(testNumber, ids);
      _unitOfWork.Commit();

      return new POSTransactionResult();
    }
  }
}
