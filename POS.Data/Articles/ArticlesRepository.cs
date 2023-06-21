using Dapper;
using POS.Common.DTOs;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Articles
{
  public class ArticlesRepository : POSRepository, IArticlesRepository
  {
    public ArticlesRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<ArticleDTO>> GetArticles()
    {
      string spString = "[dbo].[Usp_Articles_CON]";
      return (await _dbConnection.QueryAsync<ArticleDTO>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<Article> GetArticleById(int articleId)
    {
      string spString = "[dbo].[Usp_Articles_CON] @pi_ArticleId";
      return await _dbConnection.QuerySingleOrDefaultAsync<Article>(
        spString,
        new { pi_ArticleId = articleId },
        transaction: _dbTransaction);
    }

    public async Task<int> PostArticle(Article article)
    {
      var spString = "[dbo].[Usp_Articles_INS] @pi_ArticleTypeId, @ps_Code, @ps_Description, @pb_IsActive";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            pi_ArticleTypeId = article.ArticleTypeId,
            ps_Code = article.Code,
            ps_Description = article.Description,
            pb_IsActive = article.IsActive,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Article: " + ex.Message);
      }
    }

    public async Task<int> UpdateArticle(Article article)
    {
      string spString = "[dbo].[Usp_Articles_UPD] @pi_ArticleId, @pi_ArticleTypeId, @ps_Code, @ps_Description, @pb_IsActive";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_ArticleId = article.Id,
            pi_ArticleTypeId = article.ArticleTypeId,
            ps_Code = article.Code,
            ps_Description = article.Description,
            pb_IsActive = article.IsActive,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE Article: " + ex.Message);
      }
    }

    public async Task<int> DeleteArticle(int articleId)
    {
      string spString = "[dbo].[Usp_Articles_DEL] @pi_ArticleId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_ArticleId = articleId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Article: " + ex.Message);
      }
    }
  }
}
