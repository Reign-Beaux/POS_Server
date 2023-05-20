using POS.Common.DTOs;
using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Suppliers
{
  public class SuppliersService : POSService, ISuppliersService
  {
    public SuppliersService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<SupplierDTO>> GetSuppliers()
      => await _unitOfWork.SuppliersRepository.GetSuppliers();

    public async Task<Supplier> GetSupplierById(int supplierId)
      => await _unitOfWork.SuppliersRepository.GetSupplierById(supplierId);

    public async Task<POSTransactionResult> PostSupplier(Supplier supplier)
    {
      var idResult = await _unitOfWork.SuppliersRepository.PostSupplier(supplier);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdateSupplier(Supplier supplier)
    {
      var response = await _unitOfWork.SuppliersRepository.UpdateSupplier(supplier);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeleteSupplier(int supplierId)
    {
      var response = await _unitOfWork.SuppliersRepository.DeleteSupplier(supplierId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
