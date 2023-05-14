using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Business.Users
{
  public interface IUsersService
  {
    Task<List<UserDTO>> GetUsers();
    Task<User> GetUserById(int userId);
    Task<POSTransactionResult> PostUser(User user);
    Task<POSTransactionResult> UpdateUser(User user);
    Task<POSTransactionResult> DeleteUser(int userId);
  }
}
