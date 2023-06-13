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

    [HttpPost]
    public async Task<ActionResult> UpdatePurchaseDetail(int purchaseId, List<PurchaseDetail> details)
      => Ok(await _service.UpdatePurchaseDetail(purchaseId, details));

    [HttpPost("TestMerge/{testNumber}")]
    public async Task<ActionResult> TestMerge(int testNumber, List<IdsTT> ids)
      => Ok(await _service.TestMerge(testNumber, ids));
  }
}
