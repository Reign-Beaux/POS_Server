﻿using Microsoft.AspNetCore.Mvc;
using POS.Business.Selects;

namespace POS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SelectsController : ControllerBase
  {
    private readonly ISelectsService _service;

    public SelectsController(ISelectsService service)
      => _service = service;

    [HttpGet("GetAreas")]
    public async Task<ActionResult> GetAreas()
      => Ok(await _service.GetAreas());

    [HttpGet("GetArticlesTypes")]
    public async Task<ActionResult> GetArticlesTypes()
      => Ok(await _service.GetArticlesTypes());

    [HttpGet("GetEmployees")]
    public async Task<ActionResult> GetEmployees()
      => Ok(await _service.GetEmployees());

    [HttpGet("GetRoles")]
    public async Task<ActionResult> GetRoles()
      => Ok(await _service.GetRoles());
  }
}
