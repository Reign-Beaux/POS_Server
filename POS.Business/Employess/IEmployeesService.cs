using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Business.Employess
{
  public interface IEmployeesService
  {
    Task<List<EmployeeDTO>> GetEmployees();
    Task<Employee> GetEmployeeById(int employeeId);
    Task<POSTransactionResult> PostEmployee(Employee employee);
    Task<POSTransactionResult> DeleteEmployee(int employeeId);
    Task<POSTransactionResult> UpdateEmployee(Employee employee);
  }
}
