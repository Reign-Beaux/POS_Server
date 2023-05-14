namespace POS.Common.Models
{
  public class POSTransactionResult
  {
    public string Message { get; set; }
    public bool Success { get; set; } = true;
    public int IntegerReturnValue { get; set; }
  }
}
