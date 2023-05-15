using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Articles
{
  public class ArticlesService : POSService, IArticlesService
  {
    public ArticlesService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<Article>> GetArticles()
      => await _unitOfWork.ArticlesRepository.GetArticles();

    public async Task<Article> GetArticleById(int articleId)
      => await _unitOfWork.ArticlesRepository.GetArticleById(articleId);

    public async Task<POSTransactionResult> PostArticle(Article article)
    {
      var idResult = await _unitOfWork.ArticlesRepository.PostArticle(article);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdateArticle(Article article)
    {
      var response = await _unitOfWork.ArticlesRepository.UpdateArticle(article);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeleteArticle(int articleId)
    {
      var response = await _unitOfWork.ArticlesRepository.DeleteArticle(articleId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
