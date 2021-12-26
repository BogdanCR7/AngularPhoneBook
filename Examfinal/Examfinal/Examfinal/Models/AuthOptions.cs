using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Auth.AuthOptions
{
    public class AuthOptions
    {
        public string Issuer { get; set; } = "authserver";
        public string Audience { get; set; } = "resourceserver";
        public string Secret { get; set; } = "secretword12356778";
        public int TokenLifeTime { get; set; } = 3600;

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
