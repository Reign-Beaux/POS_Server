﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace POS.API.Filters
{
  public class BadRequestParse : IActionFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception == null)
        return;

      context.Result = new BadRequestObjectResult(context.Exception.Message)
      {
        StatusCode = StatusCodes.Status500InternalServerError
      };
      context.ExceptionHandled = true;
    }
  }
}
