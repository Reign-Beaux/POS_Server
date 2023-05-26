namespace POS.Common.DTOs
{
  public class PurchaseDTO
  {
    public int Id { get; set; }
    public int SupplierFullName { get; set; }
    public int UserFullName { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Taxes { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
  }
}
