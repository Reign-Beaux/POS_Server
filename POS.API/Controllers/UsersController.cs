using Microsoft.AspNetCore.Mvc;
using POS.Business.Users;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IUsersService _service;

    public UsersController(IUsersService service)
    => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetUsers()
      => Ok(await _service.GetUsers());

    [HttpGet("{userId:int}")]
    public async Task<ActionResult> GetUserById(int userId)
      => Ok(await _service.GetUserById(userId));

    [HttpPost]
    public async Task<ActionResult> PostUser(User user)
      => Ok(await _service.PostUser(user));

    [HttpPut]
    public async Task<ActionResult> UpdateUser(User user)
      => Ok(await _service.UpdateUser(user));

    [HttpDelete("{userId:int}")]
    public async Task<ActionResult> DeleteUser(int userId)
      => Ok(await _service.DeleteUser(userId));
  }
}
