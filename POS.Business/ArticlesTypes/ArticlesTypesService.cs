using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.ArticlesTypes
{
  public class ArticlesTypesService : POSService, IArticlesTypesService
  {
    public ArticlesTypesService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<ArticleType>> GetArticlesTypes()
      => await _unitOfWork.ArticlesTypesRepository.GetArticlesTypes();
  }
}
