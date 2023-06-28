namespace POS.Common.DTOs
{
  public class PurchaseDTO
  {
    public int Id { get; set; }
    public string SupplierFullName { get; set; }
    public string UserFullName { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Taxes { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
    public int Status { get; set; }
  }
}
