using POS.Common.Models;

namespace POS.Data.Login
{
  public interface ILoginRepository
  {
    Task<User> Login(string username, string password);
  }
}
