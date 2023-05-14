using POS.Common.Models;

namespace POS.Business.ArticlesTypes
{
  public interface IArticlesTypesService
  {
    Task<List<ArticleType>> GetArticlesTypes();
  }
}
