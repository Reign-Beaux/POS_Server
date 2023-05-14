using POS.Common.DTOs;
using POS.Common.Models;

namespace POS.Data.Employees
{
  public interface IEmployeesRepository
  {
    Task<List<EmployeeDTO>> GetEmployees();
    Task<Employee> GetEmployeeById (int employeeId);
    Task<int> PostEmployee (Employee employee);
    Task<int> UpdateEmployee(Employee employee);
    Task<int> DeleteEmployee (int employeeId);
  }
}
