using Dapper;
using POS.Common.DTOs;
using System.Data;

namespace POS.Data.Inventories
{
  public class InventoriesRepository : POSRepository, IInventoriesRepository
  {
    public InventoriesRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<InventoryDTO>> GetInventoryDetail()
    {
      string spString = "[dbo].[Usp_Inventory_CON]";
      return (await _dbConnection.QueryAsync<InventoryDTO>(spString, transaction: _dbTransaction)).ToList();
    }
  }
}
