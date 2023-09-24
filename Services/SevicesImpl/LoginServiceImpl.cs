using ExtraaEdge_WEB_API.DataContext;
using ExtraaEdge_WEB_API.Model;
using ExtraaEdge_WEB_API.Repository.IRepository;
using ExtraaEdge_WEB_API.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExtraaEdge_WEB_API.Services.SevicesImpl
{
    public class LoginRepository : ILoginServices
    {
        private readonly IRepository _IRepo;
        private readonly IConfiguration _IConfig;

        public LoginRepository(IRepository IRepo, IConfiguration IConfig)
        {
            _IRepo=IRepo; 
            _IConfig=IConfig;
        }

        public bool Login(LoginModel loginModel)
        {
            LoginModel login = _IRepo.LoginUser(loginModel);
            if (login != null)
            {
                
                //var token = GenerateToken(loginModel.StoreOwnerName);

                return true;
            }
            else
            {
                return false;
            }
            

        }

       

        object ILoginServices.GenerateToken(string storeOwnerName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_IConfig.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,storeOwnerName ),
            };
            var token = new JwtSecurityToken(
                _IConfig.GetSection("Jwt:Issuer").Value,
                _IConfig.GetSection("Jwt:Audience").Value,
                claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
