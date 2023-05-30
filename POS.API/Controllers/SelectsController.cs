using Microsoft.AspNetCore.Mvc;
using POS.Business.Selects;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SelectsController : ControllerBase
  {
    private readonly ISelectsService _service;

    public SelectsController(ISelectsService service)
      => _service = service;

    [HttpGet("GetAreas")]
    public async Task<ActionResult> GetAreas()
      => Ok(await _service.GetAreas());

    [HttpGet("GetArticles")]
    public async Task<ActionResult> GetArticles()
      => Ok(await _service.GetArticles());

    [HttpGet("GetArticlesTypes")]
    public async Task<ActionResult> GetArticlesTypes()
      => Ok(await _service.GetArticlesTypes());

    [HttpGet("GetBrands")]
    public async Task<ActionResult> GetBrands()
      => Ok(await _service.GetBrands());

    [HttpGet("GetEmployees")]
    public async Task<ActionResult> GetEmployees()
      => Ok(await _service.GetEmployees());

    [HttpGet("GetRoles")]
    public async Task<ActionResult> GetRoles()
      => Ok(await _service.GetRoles());

    [HttpGet("GetSuppliers")]
    public async Task<ActionResult> GetSuppliers()
      => Ok(await _service.GetSuppliers());

    [HttpGet("GetUsers")]
    public async Task<ActionResult> GetUsers()
      => Ok(await _service.GetUsers());
  }
}
