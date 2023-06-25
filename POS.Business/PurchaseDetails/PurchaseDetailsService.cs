using POS.Common.DTOs;
using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.PurchaseDetails
{
  public class PurchaseDetailsService : POSService, IPurchaseDetailsService
  {
    public PurchaseDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<PurchaseDetailDTO>> GetPurchaseDetails(int purchaseId)
      => await _unitOfWork.PurchaseDetailsRepository.GetPurchaseDetails(purchaseId);

    public async Task<PurchaseDetail> GetPurchaseDetailById(int purchaseDetailId)
      => await _unitOfWork.PurchaseDetailsRepository.GetPurchaseDetailById(purchaseDetailId);

    public async Task<POSTransactionResult> PostPurchaseDetail(PurchaseDetail purchaseDetail)
    {
      var idResult = await _unitOfWork.PurchaseDetailsRepository.PostPurchaseDetail(purchaseDetail);
      await _unitOfWork.PurchasesRepository.CalculateAmount(purchaseDetail.PurchaseId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdatePurchaseDetail(PurchaseDetail purchaseDetail)
    {
      var response = await _unitOfWork.PurchaseDetailsRepository.UpdatePurchaseDetail(purchaseDetail);
      await _unitOfWork.PurchasesRepository.CalculateAmount(purchaseDetail.PurchaseId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeletePurchaseDetail(int purchaseDetailId)
    {
      var purchaseDetail = await _unitOfWork.PurchaseDetailsRepository.GetPurchaseDetailById(purchaseDetailId);
      var response = await _unitOfWork.PurchaseDetailsRepository.DeletePurchaseDetail(purchaseDetailId);
      await _unitOfWork.PurchasesRepository.CalculateAmount(purchaseDetail.PurchaseId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
