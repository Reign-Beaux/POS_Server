using POS.Common.Models;

namespace POS.Data.Roles
{
  public interface IRolesRepository
  {
    Task<List<Role>> GetRoles();
    Task<Role> GetRoleById(int id);
    Task<int> PostRole(Role role);
    Task<int> UpdateRole(Role role);
    Task<int> DeleteRole(int roleId);
    Task UpdateRoleFeature(int roleId, List<int> featuresIds);
  }
}
