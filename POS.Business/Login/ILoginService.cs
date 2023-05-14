using POS.Common.DTOs;

namespace POS.Business.Login
{
  public interface ILoginService
  {
    Task<UserDataDTO> Login(LoginDTO login);
  }
}
