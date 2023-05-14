namespace POS.Common.DTOs
{
  public class UserDTO
  {
    public int Id { set; get; }
		public int EmployeeId { set; get; }
		public int RoleId { set; get; }
		public string Username { set; get; }
		public string Email { set; get; }
		public string Name { set; get; }
		public string PaternalSurname { set; get; }
		public string MaternalSurname { set; get; }
		public string RoleDescription { set; get; }
  }
}
