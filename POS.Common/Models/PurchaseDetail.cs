namespace POS.Common.Models
{
  public class PurchaseDetail
  {
    public int Id { set; get;}
		public int PurchaseId { set; get;}
		public int ArticleId { set; get;}
		public decimal QuantitySold { set; get;}
		public decimal Price { set; get;}
		public decimal Subtotal { set; get;}
		public decimal Taxes { set; get;}
		public decimal Total { set; get; }
  }
}
