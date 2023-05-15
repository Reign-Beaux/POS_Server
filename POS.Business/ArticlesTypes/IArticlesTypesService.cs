using POS.Common.Models;

namespace POS.Business.ArticlesTypes
{
  public interface IArticlesTypesService
  {
    Task<List<ArticleType>> GetArticlesTypes();
    Task<ArticleType> GetArticlesTypesById(int articleTypeId);
    Task<POSTransactionResult> PostArticlesTypes(ArticleType articleType);
    Task<POSTransactionResult> UpdateArticlesTypes(ArticleType articleType);
    Task<POSTransactionResult> DeleteArticlesTypes(int articleTypeId);
  }
}
