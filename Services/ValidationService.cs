using System.IdentityModel.Tokens.Jwt;
using StudentManagement.Interfaces;

namespace StudentManagement.Services;

public class ValidationService : IValidationService
{
    public async Task<bool> validatedRequestValues(string authHeader)
    {
        if (authHeader != null && authHeader.StartsWith("Bearer "))
        {
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims;
            var username = claims.FirstOrDefault(c => c.Type == "username")?.Value;
            var role = claims.FirstOrDefault(c => c.Type == "role")?.Value;
            if (role != "super")
            {
                return false;
            }
        }

        return true;
    }
}