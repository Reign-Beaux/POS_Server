namespace POS.Common.Models
{
  public class Supplier
  {
    public int Id { set; get; }
		public int BrandId { set; get; }
		public string Name { set; get; }
		public string PaternalSurname { set; get; }
		public string MaternalSurname { set; get; }
		public string Rfc { set; get; }
		public string Phone { set; get; }
		public string Cellphone { set; get; }
		public string Observations { set; get; }
    public string Email { set; get; }
  }
}
