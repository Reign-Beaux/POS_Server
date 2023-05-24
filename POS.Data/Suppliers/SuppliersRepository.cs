using Dapper;
using POS.Common.DTOs;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Suppliers
{
  public class SuppliersRepository : POSRepository, ISuppliersRepository
  {
    public SuppliersRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<SupplierDTO>> GetSuppliers()
    {
      string spString = "[dbo].[Usp_Suppliers_CON]";
      return (await _dbConnection.QueryAsync<SupplierDTO>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<Supplier> GetSupplierById(int supplierId)
    {
      string spString = "[dbo].[Usp_Suppliers_CON] @pi_SupplierId";
      var response = (await _dbConnection.QueryAsync<Supplier>(
        spString,
        new { pi_SupplierId = supplierId },
        transaction: _dbTransaction)).ToList();
      return response.FirstOrDefault();
    }

    public async Task<int> PostSupplier(Supplier supplier)
    {
      var spString = "[dbo].[Usp_Suppliers_INS] @pi_BrandId, @ps_Name, @ps_PaternalSurname, @ps_MaternalSurname, @ps_RFC, @ps_Phone, @ps_Cellphone, @ps_Observations, @ps_Email";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            pi_BrandId = supplier.BrandId,
            ps_Name = supplier.Name,
            ps_PaternalSurname = supplier.PaternalSurname,
            ps_MaternalSurname = supplier.MaternalSurname,
            ps_RFC = supplier.Rfc,
            ps_Phone = supplier.Phone,
            ps_Cellphone = supplier.Cellphone,
            ps_Observations = supplier.Observations,
            ps_Email = supplier.Email,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Supplier: " + ex.Message);
      }
    }

    public async Task<int> UpdateSupplier(Supplier supplier)
    {
      string spString = "[dbo].[Usp_Suppliers_UPD] @pi_SupplierId, @pi_BrandId, @ps_Name, @ps_PaternalSurname, @ps_MaternalSurname, @ps_RFC, @ps_Phone, @ps_Cellphone, @ps_Observations";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_SupplierId = supplier.Id,
            pi_BrandId = supplier.Id,
            ps_Name = supplier.Name,
            ps_PaternalSurname = supplier.PaternalSurname,
            ps_MaternalSurname = supplier.MaternalSurname,
            ps_RFC = supplier.Rfc,
            ps_Phone = supplier.Phone,
            ps_Cellphone = supplier.Cellphone,
            ps_Observations = supplier.Observations,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE Supplier: " + ex.Message);
      }
    }

    public async Task<int> DeleteSupplier(int supplierId)
    {
      string spString = "[dbo].[Usp_Suppliers_DEL] @pi_SupplierId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_SupplierId = supplierId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Supplier: " + ex.Message);
      }
    }
  }
}
