using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Data.Users
{
  public interface IUsersRepository
  {
    Task<List<UserDTO>> GetUsers();
    Task<User> GetUserById(int userId);
    Task<int> PostUser(User user);
    Task<int> UpdateUser(User user);
    Task<int> DeleteUser(int userId);
  }
}
