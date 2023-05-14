using Microsoft.AspNetCore.Mvc;
using POS.Business.Employess;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly IEmployeesService _service;

    public EmployeesController(IEmployeesService service)
      => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetEmployees()
      => Ok(await _service.GetEmployees());

    [HttpGet("{employeeId:int}")]
    public async Task<ActionResult> GetEmployeeById(int employeeId)
      => Ok(await _service.GetEmployeeById(employeeId));

    [HttpPost]
    public async Task<ActionResult> PostEmployee(Employee employee)
      => Ok(await _service.PostEmployee(employee));

    [HttpPut]
    public async Task<ActionResult> UpdateEmployee(Employee employee)
      => Ok(await _service.UpdateEmployee(employee));

    [HttpDelete("{employeeId:int}")]
    public async Task<ActionResult> DeleteEmployee(int employeeId)
      => Ok(await _service.DeleteEmployee(employeeId));
  }
}
