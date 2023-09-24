using ExtraaEdge_WEB_API.Model;
using ExtraaEdge_WEB_API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExtraaEdge_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _IloginServices;

        public LoginController(ILoginServices loginServices )
        {
            _IloginServices = loginServices;

        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            bool login = _IloginServices.Login(loginModel);
            
            if (login)
            {
                var token = _IloginServices.GenerateToken(loginModel.StoreOwnerName);
                return Ok(token);
            }
            else
            {
                return BadRequest("Login Failed");
            }
            
        }

        
        [HttpGet("TestToken")]
        public IActionResult Test()
        {
            return Ok("Token Validated Successfully");
        }


    }
}
