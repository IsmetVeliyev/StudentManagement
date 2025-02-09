using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Dtos.User;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class TokenService:ITokenService
{
    private readonly IConfiguration _config;
    private readonly IClaimService _claim;

    public TokenService(IConfiguration configuration,IClaimService claim)
    {
        _config = configuration;
        _claim = claim;


    }
    public string generateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
            _claim.getClaim(user),
            expires:DateTime.Now.AddMinutes(10),
            signingCredentials:credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

