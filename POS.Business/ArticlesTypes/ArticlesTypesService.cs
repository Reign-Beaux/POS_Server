using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.ArticlesTypes
{
  public class ArticlesTypesService : POSService, IArticlesTypesService
  {
    public ArticlesTypesService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<ArticleType>> GetArticlesTypes()
      => await _unitOfWork.ArticlesTypesRepository.GetArticlesTypes();

    public async Task<ArticleType> GetArticlesTypesById(int articleTypeId)
      => await _unitOfWork.ArticlesTypesRepository.GetArticlesTypesById(articleTypeId);

    public async Task<POSTransactionResult> PostArticlesTypes(ArticleType articleType)
    {
      var idResult = await _unitOfWork.ArticlesTypesRepository.PostArticlesTypes(articleType);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdateArticlesTypes(ArticleType articleType)
    {
      var response = await _unitOfWork.ArticlesTypesRepository.UpdateArticlesTypes(articleType);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeleteArticlesTypes(int articleTypeId)
    {
      var response = await _unitOfWork.ArticlesTypesRepository.DeleteArticlesTypes(articleTypeId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
