using Microsoft.AspNetCore.Mvc;
using POS.Business.Articles;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArticlesController : ControllerBase
  {
    private readonly IArticlesService _service;

    public ArticlesController(IArticlesService service)
    => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetArticles()
      => Ok(await _service.GetArticles());

    [HttpGet("{articleId:int}")]
    public async Task<ActionResult> GetArticleById(int articleId)
      => Ok(await _service.GetArticleById(articleId));

    [HttpPost]
    public async Task<ActionResult> PostArticle(Article article)
      => Ok(await _service.PostArticle(article));

    [HttpPut]
    public async Task<ActionResult> UpdateArticle(Article article)
      => Ok(await _service.UpdateArticle(article));

    [HttpDelete("{articleId:int}")]
    public async Task<ActionResult> DeleteArticle(int articleId)
      => Ok(await _service.DeleteArticle(articleId));
  }
}
