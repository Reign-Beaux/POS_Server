using Microsoft.AspNetCore.Mvc;
using POS.Business.PurchaseDetails;
using POS.Common.Models;
using POS.Common.TableTypes;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PurchaseDetailsController : ControllerBase
  {
    private readonly IPurchaseDetailsService _service;

    public PurchaseDetailsController(IPurchaseDetailsService service)
    => _service = service;

    [HttpGet("GetPurchaseDetails/{purchaseId:int}")]
    public async Task<ActionResult> GetPurchaseDetails(int purchaseId)
      => Ok(await _service.GetPurchaseDetails(purchaseId));

    [HttpGet("GetPurchaseDetailById/{purchaseDetailId:int}")]
    public async Task<ActionResult> GetPurchaseDetailById(int purchaseDetailId)
      => Ok(await _service.GetPurchaseDetailById(purchaseDetailId));

    [HttpPost]
    public async Task<ActionResult> PostPurchaseDetail(PurchaseDetail purchaseDetail)
      => Ok(await _service.PostPurchaseDetail(purchaseDetail));

    [HttpPut]
    public async Task<ActionResult> UpdatePurchaseDetail(PurchaseDetail purchaseDetail)
      => Ok(await _service.UpdatePurchaseDetail(purchaseDetail));

    [HttpDelete("{purchaseDetailId:int}")]
    public async Task<ActionResult> DeletePurchaseDetail(int purchaseDetailId)
      => Ok(await _service.DeletePurchaseDetail(purchaseDetailId));
  }
}
