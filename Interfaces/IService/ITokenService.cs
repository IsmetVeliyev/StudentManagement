using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface ITokenService
{
    public string generateToken(User user);
}