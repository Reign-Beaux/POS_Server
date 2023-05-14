using POS.Common.DTOs;
using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Employess
{
  internal class EmployeeService : POSService, IEmployeesService
  {
    public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<EmployeeDTO>> GetEmployees()
      => await _unitOfWork.EmployeesRepository.GetEmployees();

    public async Task<Employee> GetEmployeeById(int employeeId)
      => await _unitOfWork.EmployeesRepository.GetEmployeeById(employeeId);

    public async Task<POSTransactionResult> PostEmployee(Employee employee)
    {
      var idResult = await _unitOfWork.EmployeesRepository.PostEmployee(employee);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> DeleteEmployee(int employeeId)
    {
      var response = await _unitOfWork.EmployeesRepository.DeleteEmployee(employeeId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> UpdateEmployee(Employee employee)
    {
      var response = await _unitOfWork.EmployeesRepository.UpdateEmployee(employee);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }
  }
}
