using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Data.Articles
{
  public interface IArticlesRepository
  {
    Task<List<ArticleDTO>> GetArticles();
    Task<Article> GetArticleById(int articleId);
    Task<int> PostArticle(Article article);
    Task<int> UpdateArticle(Article article);
    Task<int> DeleteArticle(int articleId);
  }
}
