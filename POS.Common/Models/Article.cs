namespace POS.Common.Models
{
  public class Article : POSCatalogue
  {
    public int ArticleTypeId { set; get; }
    public bool IsActive { set; get; }
  }
}
