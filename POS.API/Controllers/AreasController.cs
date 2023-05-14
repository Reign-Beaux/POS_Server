using Microsoft.AspNetCore.Mvc;
using POS.Business.Areas;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AreasController : ControllerBase
  {
    private readonly IAreasService _service;

    public AreasController(IAreasService service)
    => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetAreas()
      => Ok(await _service.GetAreas());

    [HttpGet("{areaId:int}")]
    public async Task<ActionResult> GetAreaById(int areaId)
      => Ok(await _service.GetAreaById(areaId));

    [HttpPost]
    public async Task<ActionResult> PostArea(Area area)
      => Ok(await _service.PostArea(area));

    [HttpPut]
    public async Task<ActionResult> UpdateArea(Area area)
      => Ok(await _service.UpdateArea(area));

    [HttpDelete("{areaId:int}")]
    public async Task<ActionResult> DeleteArea(int areaId)
      => Ok(await _service.DeleteArea(areaId));
  }
}
