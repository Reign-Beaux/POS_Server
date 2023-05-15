using POS.Common.Models;

namespace POS.Data.ArticleTypes
{
  public interface IArticlesTypesRepository
  {
    Task<List<ArticleType>> GetArticlesTypes();
    Task<ArticleType> GetArticlesTypesById(int articleTypeId);
    Task<int> PostArticlesTypes(ArticleType articleType);
    Task<int> UpdateArticlesTypes(ArticleType articleType);
    Task<int> DeleteArticlesTypes(int articleTypeId);
  }
}
