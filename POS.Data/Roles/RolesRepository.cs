using Dapper;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Roles
{
  public class RolesRepository : POSRepository, IRolesRepository
  {
    public RolesRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<Role>> GetRoles()
    {
      string spString = "[dbo].[Usp_Roles_CON]";
      return (await _dbConnection.QueryAsync<Role>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<Role> GetRoleById(int id)
    {
      string spString = "[dbo].[Usp_Roles_CON] @pi_RoleId";
      try
      {
        var response = (await _dbConnection.QueryAsync<Role>(
          spString,
          new { pi_RoleId = id },
          transaction: _dbTransaction)).ToList();
        return response.FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error retrieving the Roles: " + ex.Message);
      }
    }

    public async Task<int> PostRole(Role role)
    {
      var spString = "[dbo].[Usp_Roles_INS] @ps_Code, @ps_Description";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            ps_Code = role.Code,
            ps_Description = role.Description,
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT Role: " + ex.Message);
      }
    }

    public async Task<int> UpdateRole(Role role)
    {
      string spString = "[dbo].[Usp_Roles_UPD] @pi_RoleId, @ps_Code, @ps_Description";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_RoleId = role.Id,
            ps_Code = role.Code,
            ps_Description = role.Description,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE Role: " + ex.Message);
      }
    }

    public async Task<int> DeleteRole(int roleId)
    {
      string spString = "[dbo].[Usp_Roles_DEL] @pi_RoleId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_RoleId = roleId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE Role: " + ex.Message);
      }
    }
  }
}
