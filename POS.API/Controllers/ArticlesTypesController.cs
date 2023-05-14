using Microsoft.AspNetCore.Mvc;
using POS.Business.ArticlesTypes;

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
  }
}
