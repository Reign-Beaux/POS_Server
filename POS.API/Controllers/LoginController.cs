using Microsoft.AspNetCore.Mvc;
using POS.Business.Login;
using POS.Common.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly ILoginService _service;

    public LoginController(ILoginService service)
      => _service = service;

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO login)
      => Ok(await _service.Login(login));
  }
}
