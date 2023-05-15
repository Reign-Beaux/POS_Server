using POS.Common.Models;

namespace POS.Data.Articles
{
  public interface IArticlesRepository
  {
    Task<List<Article>> GetArticles();
    Task<Article> GetArticleById(int articleId);
    Task<int> PostArticle(Article article);
    Task<int> UpdateArticle(Article article);
    Task<int> DeleteArticle(int articleId);
  }
}
