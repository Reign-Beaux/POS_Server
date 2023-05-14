using Dapper;
using POS.Common.DTOs;
using POS.Common.Models;
using System.Data;

namespace POS.Data.Employees
{
  public class EmployeesRepository : POSRepository, IEmployeesRepository
  {
    public EmployeesRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<EmployeeDTO>> GetEmployees()
    {
      string spString = "[dbo].[Usp_Employees_CON]";
      return (await _dbConnection.QueryAsync<EmployeeDTO>(spString, transaction: _dbTransaction)).ToList();
    }

    public async Task<Employee> GetEmployeeById(int employeeId)
    {
      string spString = "[dbo].[Usp_Employees_CON] @pi_EmployeeId";
      try
      {
        var response = (await _dbConnection.QueryAsync<Employee>(
          spString,
          new { pi_EmployeeId = employeeId },
          transaction: _dbTransaction)).ToList();
        return response.FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error retrieving the Employees: " + ex.Message);
      }
    }

    public async Task<int> PostEmployee(Employee employee)
    {
      var spString = "[dbo].[Usp_Employees_INS] @pi_AreaId, @ps_Name, @ps_PaternalSurname, @ps_MaternalSurname";
      try
      {
        return (await _dbConnection.QueryAsync<int>(
          spString,
          new
          {
            pi_AreaId = employee.AreaId,
            ps_Name = employee.Name,
            ps_PaternalSurname = employee.PaternalSurname,
            ps_MaternalSurname = employee.MaternalSurname
          },
          transaction: _dbTransaction)
        ).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw new Exception("Error to INSERT employee: " + ex.Message);
      }
    }

    public async Task<int> UpdateEmployee(Employee employee)
    {
      string spString = "[dbo].[Usp_Employees_UPD] @pi_EmployeeId, @pi_AreaId, @ps_Name, @ps_PaternalSurname, @ps_MaternalSurname";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          {
            pi_EmployeeId = employee.Id,
            pi_AreaId = employee.AreaId,
            ps_Name = employee.Name,
            ps_PaternalSurname = employee.PaternalSurname,
            ps_MaternalSurname = employee.MaternalSurname,
          },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to UPDATE employee: " + ex.Message);
      }
    }

    public async Task<int> DeleteEmployee(int employeeId)
    {
      string spString = "[dbo].[Usp_Employees_DEL] @pi_EmployeeId";
      try
      {
        return await _dbConnection.ExecuteAsync(
          spString,
          new
          { pi_EmployeeId = employeeId },
          transaction: _dbTransaction);
      }
      catch (Exception ex)
      {
        throw new Exception("Error to DELETE employee: " + ex.Message);
      }
    }
  }
}
