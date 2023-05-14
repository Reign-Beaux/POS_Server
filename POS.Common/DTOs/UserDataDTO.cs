using POS.Common.Models;

namespace POS.Common.DTOs
{
  public class UserDataDTO
  {
    public string Token { get; set; }
    public List<Feature> Features { get; set; }
  }
}
