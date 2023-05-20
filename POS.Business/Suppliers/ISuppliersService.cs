using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Business.Suppliers
{
  public interface ISuppliersService
  {
    Task<List<SupplierDTO>> GetSuppliers();
    Task<Supplier> GetSupplierById(int supplierId);
    Task<POSTransactionResult> PostSupplier(Supplier supplier);
    Task<POSTransactionResult> DeleteSupplier(int supplierId);
    Task<POSTransactionResult> UpdateSupplier(Supplier supplier);
  }
}
