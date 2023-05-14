using Dapper;
using POS.Common.Models;
using System.Data;

namespace POS.Data.ArticleTypes
{
  public class ArticlesTypesRepository : POSRepository, IArticlesTypesRepository
  {
    public ArticlesTypesRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<ArticleType>> GetArticlesTypes()
    {
      string spString = "[dbo].[Usp_ArticleTypes_CON]";
      try
      {
        return (await _dbConnection.QueryAsync<ArticleType>(spString, transaction: _dbTransaction)).ToList();
      }
      catch (Exception ex)
      {
        throw new Exception("Error retrieving the Articles Types: " + ex.Message);
      }
    }
  }
}
