using Dapper;
using Microsoft.Extensions.Configuration;
using POS.Common.DTOs;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Users
{
  public class UsersRepository : POSRepository, IUsersRepository
  {
    private readonly string _encrytpKey =
        new ConfigurationBuilder()
          .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
          .Build()["EncryptKey"];

    public UsersRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<UserDTO>> GetUsers()
    {
      string spString = "[dbo].[Usp_Users_CON]";
      return (await _dbConnection.QueryAsync<UserDTO>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<User> GetUserById(int userId)
    {
      string spString = "[dbo].[Usp_Users_CON] @pi_UserId";
      var response = (await _dbConnection.QueryAsync<User>(
        spString,
        new { pi_UserId = userId },
        transaction: _dbTransaction)).ToList();
      return response.FirstOrDefault();
    }

    public async Task<int> PostUser(User user)
    {
      var spString = "[dbo].[Usp_Users_INS] @pi_EmployeeId, @pi_RoleId, @ps_Username, @ps_Password, @ps_Email, @ps_EncryptKey";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            pi_EmployeeId = user.EmployeeId,
            pi_RoleId = user.RoleId,
            ps_Username = user.Username,
            ps_Password = user.Password,
            ps_Email = user.Email,
            ps_EncryptKey = _encrytpKey
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT User: " + ex.Message);
      }
    }

    public async Task<int> UpdateUser(User user)
    {
      string spString = "[dbo].[Usp_Users_UPD] @pi_UserId, @pi_EmployeeId, @pi_RoleId, @ps_Username, @ps_Password, @ps_Email, @ps_EncryptKey";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_UserId = user.Id,
            pi_EmployeeId = user.EmployeeId,
            pi_RoleId = user.RoleId,
            ps_Username = user.Username,
            ps_Password = user.Password,
            ps_Email = user.Email,
            ps_EncryptKey = _encrytpKey
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE User: " + ex.Message);
      }
    }

    public async Task<int> DeleteUser(int userId)
    {
      string spString = "[dbo].[Usp_Users_DEL] @pi_UserId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_UserId = userId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE User: " + ex.Message);
      }
    }
  }
}
