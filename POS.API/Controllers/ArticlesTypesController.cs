using Microsoft.AspNetCore.Mvc;
using POS.Business.ArticlesTypes;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArticlesTypesController : ControllerBase
  {
    private readonly IArticlesTypesService _service;

    public ArticlesTypesController(IArticlesTypesService service)
      => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetArticlesTypes()
      => Ok(await _service.GetArticlesTypes());

    [HttpGet("{articleTypeId:int}")]
    public async Task<ActionResult> GetAreaById(int articleTypeId)
      => Ok(await _service.GetArticlesTypesById(articleTypeId));

    [HttpPost]
    public async Task<ActionResult> PostArea(ArticleType articleType)
      => Ok(await _service.PostArticlesTypes(articleType));

    [HttpPut]
    public async Task<ActionResult> UpdateArea(ArticleType articleType)
      => Ok(await _service.UpdateArticlesTypes(articleType));

    [HttpDelete("{articleTypeId:int}")]
    public async Task<ActionResult> DeleteArea(int articleTypeId)
      => Ok(await _service.DeleteArticlesTypes(articleTypeId));
  }
}
