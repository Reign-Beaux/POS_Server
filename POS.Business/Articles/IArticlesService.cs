using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Business.Articles
{
  public interface IArticlesService
  {
    Task<List<ArticleDTO>> GetArticles();
    Task<Article> GetArticleById(int articleId);
    Task<POSTransactionResult> PostArticle(Article article);
    Task<POSTransactionResult> DeleteArticle(int articleId);
    Task<POSTransactionResult> UpdateArticle(Article article);
  }
}
