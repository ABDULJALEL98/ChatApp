using ChatApp.Application.Persistance.Contracts;
using ChatApp.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace ChatApp.Persistence.Repositories;

public class TokenServices : ITokenServices
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _symmetricSecurityKey;
    public TokenServices(IConfiguration configuration)
    {
        _configuration = configuration;
        _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[key: "Token:Key"]));
    }

    

    public string GetToken(AppUser user)
    {

        var claim = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim (JwtRegisteredClaimNames.Name, user.UserName)
        };
        var creds = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescribtor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claim),
            Expires = DateTime.Now.AddDays(value: 10),
            Issuer = _configuration[key: "JWT:Issuer"],
            SigningCredentials = creds,

        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescribtor);
        return tokenHandler.WriteToken(token);

    }
}
