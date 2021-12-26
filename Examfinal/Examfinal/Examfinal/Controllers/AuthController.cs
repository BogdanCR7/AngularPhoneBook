using Auth.AuthOptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly  ApplicationContext _applicationContext;
        private readonly IOptions<AuthOptions> _options;
        public AuthController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody]LoginRequest login)
        {
            var user = AuthenticateUser(login.Email, login.Password);
            if (user != null)
            {
                var token = GenerateJwt(user);
                return Ok(new
                {
                    access_token = token
                });
            }
            return Unauthorized();
        }
      private  Account AuthenticateUser(string email, string password)
        {
            return _applicationContext.accounts.Include(c => c.Roles).SingleOrDefault(x=>(x.Email==email && x.Password==password));
        }
        private string GenerateJwt(Account user)
        {
            AuthOptions authparams = new AuthOptions();
            //var authparams = _options.Value;
            var key = authparams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> {
                new Claim( JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString())
            };
           
            foreach (Role item in user.Roles)
            {
                claims.Add(new Claim("role",item.role));
            }
            var token = new JwtSecurityToken(authparams.Issuer,authparams.Audience,
                claims,expires:DateTime.Now.AddSeconds(authparams.TokenLifeTime),signingCredentials:credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
