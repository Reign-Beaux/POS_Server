using POS.Common.Models;

namespace POS.Business.Roles
{
  public interface IRolesService
  {
    Task<List<Role>> GetRoles();
    Task<Role> GetRoleById(int roleId);
    Task<POSTransactionResult> PostRole(Role role);
    Task<POSTransactionResult> DeleteRole(int roleId);
    Task<POSTransactionResult> UpdateRole(Role role);
    Task<POSTransactionResult> UpdateRoleFeature(int roleId, List<RoleFeatures> roleFeatures);
  }
}
