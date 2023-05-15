namespace POS.Common.DTOs
{
  public class ArticleDTO
  {
    public int Id { get; set; }
    public string ArticleTypeDescription { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
  }
}
