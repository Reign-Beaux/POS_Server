using Microsoft.AspNetCore.Mvc.Filters;

namespace POS.API.Filters
{
  public class POSExceptionsLogger : ExceptionFilterAttribute
  {
    private readonly ILogger<POSExceptionsLogger> _logger;
    string folderPath = @"E:\Logs";
    private string filePath = @"E:\Logs\error.txt";
    public POSExceptionsLogger(ILogger<POSExceptionsLogger> logger)
      => _logger = logger;

    public override void OnException(ExceptionContext context)
    {
      if (!Directory.Exists(folderPath))
        Directory.CreateDirectory(folderPath);

      using (StreamWriter sw = File.CreateText(filePath))
        sw.WriteLine(context.Exception.Message);

      _logger.LogError(context.Exception, context.Exception.Message);
      base.OnException(context);
    }
  }
}
