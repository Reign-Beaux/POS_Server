namespace POS.Common.Models
{
  public class Purchase
  {
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public int UserId { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Taxes { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
    public int Status { get; set; }
  }
}
