using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Data.Suppliers
{
  public interface ISuppliersRepository
  {
    Task<List<SupplierDTO>> GetSuppliers();
    Task<Supplier> GetSupplierById(int supplierId);
    Task<int> PostSupplier(Supplier supplier);
    Task<int> UpdateSupplier(Supplier supplier);
    Task<int> DeleteSupplier(int supplierId);
  }
}
