using System.Security.Claims;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Repository;

namespace StudentManagement.Services;

public class ClaimService :IClaimService
{
    public ClaimService()
    {
        
    }
    public  List<Claim> getClaim (User user)
    {
        var claims = new List<Claim>
        {
            new Claim("username",user.gmail),
            new Claim("role",user.role)
        };

        return claims;
    }
}