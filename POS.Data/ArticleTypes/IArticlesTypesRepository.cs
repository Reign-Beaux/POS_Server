using POS.Common.Models;

namespace POS.Data.ArticleTypes
{
  public interface IArticlesTypesRepository
  {
    Task<List<ArticleType>> GetArticlesTypes();
  }
}
