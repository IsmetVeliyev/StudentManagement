using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(string gmail);
}