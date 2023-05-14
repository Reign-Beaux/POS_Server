using POS.Common.Models;

namespace POS.Data.Features
{
  public interface IFeaturesRepository
  {
    Task<List<Feature>> GetFeaturesByRole(int roleId);
  }
}
