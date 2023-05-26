using POS.Common.DTOs;
using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Purchases
{
  public class PurchasesService : POSService, IPurchasesService
  {
    public PurchasesService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<PurchaseDTO>> GetPurchases()
      => await _unitOfWork.PurchasesRepository.GetPurchases();

    public async Task<Purchase> GetPurchaseById(int PurchaseId)
      => await _unitOfWork.PurchasesRepository.GetPurchaseById(PurchaseId);

    public async Task<POSTransactionResult> PostPurchase(Purchase Purchase)
    {
      var idResult = await _unitOfWork.PurchasesRepository.PostPurchase(Purchase);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdatePurchase(Purchase Purchase)
    {
      var response = await _unitOfWork.PurchasesRepository.UpdatePurchase(Purchase);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeletePurchase(int PurchaseId)
    {
      var response = await _unitOfWork.PurchasesRepository.DeletePurchase(PurchaseId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
