using POS.Business.Roles;
using POS.Common.Models;
using POS.Data.UnitsOfWork;

namespace POS.Business.Roles
{
  public class RolesService : POSService, IRolesService
  {
    public RolesService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<List<Role>> GetRoles()
      => await _unitOfWork.RolesRepository.GetRoles();

    public async Task<Role> GetRoleById(int roleId)
      => await _unitOfWork.RolesRepository.GetRoleById(roleId);

    public async Task<POSTransactionResult> PostRole(Role role)
    {
      var idResult = await _unitOfWork.RolesRepository.PostRole(role);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = idResult };
    }

    public async Task<POSTransactionResult> DeleteRole(int roleId)
    {
      var response = await _unitOfWork.RolesRepository.DeleteRole(roleId);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> UpdateRole(Role role)
    {
      var response = await _unitOfWork.RolesRepository.UpdateRole(role);
      _unitOfWork.Commit();

      return new() { IntegerReturnValue = response };
    }

    public async Task<POSTransactionResult> UpdateRoleFeature(int roleId, List<RoleFeatures> roleFeatures)
    {
      await _unitOfWork.RolesRepository.UpdateRoleFeature(roleId, roleFeatures);
      _unitOfWork.Commit();

      return new POSTransactionResult();
    }
  }
}
