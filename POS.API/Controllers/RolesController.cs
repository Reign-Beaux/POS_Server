using Microsoft.AspNetCore.Mvc;
using POS.Business.Roles;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RolesController : ControllerBase
  {
    private readonly IRolesService _service;

    public RolesController(IRolesService service)
      => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetRoles()
      => Ok(await _service.GetRoles());

    [HttpGet("{roleId:int}")]
    public async Task<ActionResult> GetRoleById(int roleId)
      => Ok(await _service.GetRoleById(roleId));

    [HttpPost]
    public async Task<ActionResult> PostRole(Role role)
      => Ok(await _service.PostRole(role));

    [HttpPut]
    public async Task<ActionResult> UpdateRole(Role role)
      => Ok(await _service.UpdateRole(role));

    [HttpDelete("{roleId:int}")]
    public async Task<ActionResult> DeleteRole(int roleId)
      => Ok(await _service.DeleteRole(roleId));

    [HttpPost("UpdateRoleFeature/{roleId}")]
    public async Task<ActionResult> UpdateRoleFeature(int roleId, List<int> featuresIds)
      => Ok(await _service.UpdateRoleFeature(roleId, featuresIds));
  }
}
