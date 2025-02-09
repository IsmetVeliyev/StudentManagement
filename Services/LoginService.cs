using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.User;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Repository;

namespace StudentManagement.Services;

public class LoginService :ILoginService
{
    private readonly IUserRepository _user;
    private readonly ITokenService _token;
    public LoginService(IUserRepository user,ITokenService token)
    {
        _user = user;
        _token = token;

    }
    
    public async Task<string> checkUpAsync(LoginDto loginDto)
    {
        var user = await _user.GetByIdAsync(loginDto.gmail);
        if (user == null)
            return "#A1"; 

        if (user.password == loginDto.password)
            return _token.generateToken(user);

        return "#A2"; 
    }
}