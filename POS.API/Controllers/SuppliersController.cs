using Microsoft.AspNetCore.Mvc;
using POS.Business.Suppliers;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuppliersController : ControllerBase
  {
    private readonly ISuppliersService _service;

    public SuppliersController(ISuppliersService service)
    => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetSuppliers()
      => Ok(await _service.GetSuppliers());

    [HttpGet("{supplierId:int}")]
    public async Task<ActionResult> GetSupplierById(int supplierId)
      => Ok(await _service.GetSupplierById(supplierId));

    [HttpPost]
    public async Task<ActionResult> PostSupplier(Supplier supplier)
      => Ok(await _service.PostSupplier(supplier));

    [HttpPut]
    public async Task<ActionResult> UpdateSupplier(Supplier supplier)
      => Ok(await _service.UpdateSupplier(supplier));

    [HttpDelete("{supplierId:int}")]
    public async Task<ActionResult> DeleteSupplier(int supplierId)
      => Ok(await _service.DeleteSupplier(supplierId));
  }
}
