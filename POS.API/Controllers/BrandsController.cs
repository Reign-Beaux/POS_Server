using Microsoft.AspNetCore.Mvc;
using POS.Business.Brands;
using POS.Common.Models;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BrandsController : ControllerBase
  {
    private readonly IBrandsService _service;

    public BrandsController(IBrandsService service)
    => _service = service;

    [HttpGet]
    public async Task<ActionResult> GetBrands()
      => Ok(await _service.GetBrands());

    [HttpGet("{brandId:int}")]
    public async Task<ActionResult> GetBrandById(int brandId)
      => Ok(await _service.GetBrandById(brandId));

    [HttpPost]
    public async Task<ActionResult> PostBrand(Brand brand)
      => Ok(await _service.PostBrand(brand));

    [HttpPut]
    public async Task<ActionResult> UpdateBrand(Brand brand)
      => Ok(await _service.UpdateBrand(brand));

    [HttpDelete("{brandId:int}")]
    public async Task<ActionResult> DeleteBrand(int brandId)
      => Ok(await _service.DeleteBrand(brandId));
  }
}
