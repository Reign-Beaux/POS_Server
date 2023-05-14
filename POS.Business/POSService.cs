using POS.Data.UnitsOfWork;

namespace POS.Business
{
  public class POSService
  {
    private protected readonly IUnitOfWork _unitOfWork;

    public POSService(IUnitOfWork unitOfWork)
      => _unitOfWork = unitOfWork;
  }
}
