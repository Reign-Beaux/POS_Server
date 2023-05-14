using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using POS.Common.DTOs;
using POS.Common.Models;
using POS.Data.UnitsOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using static POS.Common.Consts.POSConsts;

namespace POS.Business.Login
{
  public class LoginService : POSService, ILoginService
  {
    public LoginService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    public async Task<UserDataDTO> Login(LoginDTO login)
    {
      User user = await _unitOfWork.LoginRepository.Login(login.Username, login.Password) ?? throw new Exception("Bad credentials");
      Employee employee = await _unitOfWork.EmployeesRepository.GetEmployeeById(user.EmployeeId);
      Role role = await _unitOfWork.RolesRepository.GetRoleById(user.RoleId);
      List<Feature> features = await _unitOfWork.FeaturesRepository.GetFeaturesByRole(user.RoleId);

      var claims = new List<Claim>
      {
        new(ClaimTypes.Name, user.Username),
        new(ClaimNames.USER_CLAIM_KEY, JsonSerializer.Serialize(
          new {
            Username = user.Username,
            FullName = $"{employee.Name} {employee.PaternalSurname} {employee.MaternalSurname}",
            Email = user.Email,
            RoleDescription = role.Description
          }
        )),
      };

      var jwtKey =
        new ConfigurationBuilder()
          .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
          .Build()["JWTKey"];

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
      var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
      var expiracion = DateTime.UtcNow.AddDays(1);

      var token =
        new JwtSecurityToken(
          issuer: null,
          audience: null,
          claims: claims,
          expires: expiracion,
          signingCredentials: signingCredentials);

      return new UserDataDTO()
      {
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Features = features,
      };
    }
  }
}
