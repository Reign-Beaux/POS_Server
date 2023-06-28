namespace POS.Common.Consts
{
  public class POSConsts
  {
    public static class ClaimNames
    {
      public const string USER_CLAIM_KEY = "USER_CLAIM";
    }

    public enum PurchaseStatus
    {
      Pendiente = 1,
      Confirmado = 2,
      Programado = 3,
      Recibido = 4,
    }
  }
}
