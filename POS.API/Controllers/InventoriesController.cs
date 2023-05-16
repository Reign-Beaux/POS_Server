using Microsoft.AspNetCore.Mvc;
using POS.Business.Inventories;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoriesController : ControllerBase
  {
    private readonly IInventoriesService _service;

    public InventoriesController(IInventoriesService service)
    => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetInventoryDetail()
      => Ok(await _service.GetInventoryDetail());
  }
}
