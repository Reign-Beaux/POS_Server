using POS.Common.DTOs;
using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Users
{
  public class UsersService : POSService, IUsersService
  {
    public UsersService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<UserDTO>> GetUsers()
      => await _unitOfWork.UsersRepository.GetUsers();

    public async Task<User> GetUserById(int userId)
      => await _unitOfWork.UsersRepository.GetUserById(userId);

    public async Task<POSTransactionResult> PostUser(User user)
    {
      var idResult = await _unitOfWork.UsersRepository.PostUser(user);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> UpdateUser(User user)
    {
      var response = await _unitOfWork.UsersRepository.UpdateUser(user);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> DeleteUser(int userId)
    {
      var response = await _unitOfWork.UsersRepository.DeleteUser(userId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
