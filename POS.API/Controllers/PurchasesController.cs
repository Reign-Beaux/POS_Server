using Microsoft.AspNetCore.Mvc;
using POS.Business.Purchases;
using POS.Common.DTOs;
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
    public async Task<ActionResult> PostPurchase(PurchaseRequestDTO purchaseRequest)
      => Ok(await _service.PostPurchase(purchaseRequest));

    [HttpPut]
    public async Task<ActionResult> UpdatePurchase(PurchaseRequestDTO purchaseRequest)
      => Ok(await _service.UpdatePurchase(purchaseRequest));

    [HttpDelete("{purchaseId:int}")]
    public async Task<ActionResult> DeletePurchase(int purchaseId)
      => Ok(await _service.DeletePurchase(purchaseId));
  }
}
