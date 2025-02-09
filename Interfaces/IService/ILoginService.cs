using StudentManagement.Dtos.User;

namespace StudentManagement.Interfaces;

public interface ILoginService
{
    public Task<string> checkUpAsync(LoginDto loginDto);
}