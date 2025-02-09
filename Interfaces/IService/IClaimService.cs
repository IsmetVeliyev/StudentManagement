using System.Security.Claims;
using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface IClaimService
{
    public List<Claim> getClaim(User user);
}