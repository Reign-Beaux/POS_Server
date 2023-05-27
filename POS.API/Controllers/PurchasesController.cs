using Microsoft.AspNetCore.Mvc;
using POS.Business.Purchases;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PurchasesController : ControllerBase
  {
    private readonly IPurchasesService _service;

    public PurchasesController(IPurchasesService service)
    => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetPurchases()
      => Ok(await _service.GetPurchases());

    [HttpGet("{purchaseId:int}")]
    public async Task<ActionResult> GetPurchaseById(int purchaseId)
      => Ok(await _service.GetPurchaseById(purchaseId));

    [HttpPost]
    public async Task<ActionResult> PostPurchase([FromBody] int supplierId, [FromBody] string userName)
      => Ok(await _service.PostPurchase(supplierId, userName));

    [HttpPut]
    public async Task<ActionResult> UpdatePurchase(Purchase purchase)
      => Ok(await _service.UpdatePurchase(purchase));

    [HttpDelete("{purchaseId:int}")]
    public async Task<ActionResult> DeletePurchase(int purchaseId)
      => Ok(await _service.DeletePurchase(purchaseId));
  }
}
