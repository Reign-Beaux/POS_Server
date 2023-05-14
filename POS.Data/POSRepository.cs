using System.Data;

namespace POS.Data
{
  public class POSRepository
  {
    private protected readonly IDbTransaction _dbTransaction;
    private protected readonly IDbConnection _dbConnection;

    public POSRepository(IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
        _dbConnection = dbTransaction.Connection!;
    }
  }
}
