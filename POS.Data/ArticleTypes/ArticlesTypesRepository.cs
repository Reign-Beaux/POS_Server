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
      return (await _dbConnection.QueryAsync<ArticleType>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<ArticleType> GetArticlesTypesById(int articleTypeId)
    {
      string spString = "[dbo].[Usp_ArticleTypes_CON] @pi_ArticleTypeId";
      var response = (await _dbConnection.QueryAsync<ArticleType>(
        spString,
        new { pi_ArticleTypeId = articleTypeId },
        transaction: _dbTransaction)).ToList();
      return response.FirstOrDefault();
    }

    public async Task<int> PostArticlesTypes(ArticleType articleType)
    {
      var spString = "[dbo].[Usp_ArticleTypes_INS] @ps_Code, @ps_Description";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            ps_Code = articleType.Code,
            ps_Description = articleType.Description,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Area: " + ex.Message);
      }
    }

    public async Task<int> UpdateArticlesTypes(ArticleType articleType)
    {
      string spString = "[dbo].[Usp_ArticleTypes_UPD] @pi_ArticleTypeId, @ps_Code, @ps_Description";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_ArticleTypeId = articleType.Id,
            ps_Code = articleType.Code,
            ps_Description = articleType.Description,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE Area: " + ex.Message);
      }
    }

    public async Task<int> DeleteArticlesTypes(int articleTypeId)
    {
      string spString = "[dbo].[Usp_ArticleTypes_DEL] @pi_ArticleTypeId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_ArticleTypeId = articleTypeId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Area: " + ex.Message);
      }
    }
  }
}
