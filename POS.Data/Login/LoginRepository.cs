using Dapper;
using Microsoft.Extensions.Configuration;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Login
{
  public class LoginRepository : POSRepository, ILoginRepository
  {
    private readonly string _encrytpKey =
        new ConfigurationBuilder()
          .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
          .Build()["EncryptKey"];

    public LoginRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<User> Login(string username, string password)
    {
      string spString = "[dbo].[Usp_Users_LOG] @ps_Username, @ps_Password, @ps_EncryptKey";

      var response = await _dbConnection.QueryAsync<User>(
        spString,
        new
        {
          ps_Username = username,
          ps_Password = password,
          ps_EncryptKey = _encrytpKey
        },
        transaction: _dbTransaction);

      return response.FirstOrDefault();
    }
  }
}
