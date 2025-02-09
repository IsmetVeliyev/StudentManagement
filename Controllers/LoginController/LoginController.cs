using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.User;
using StudentManagement.Interfaces;
using StudentManagement.Repository;
using StudentManagement.Services;

namespace StudentManagement.Controllers;

[Route("management/account")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _userService;

    public LoginController(ILoginService service)
    {
        _userService = service;
    }
    
    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
       var result= await _userService.checkUpAsync(loginDto);
       if (result.Contains("#A1"))
           return Unauthorized("Type available gmail");

       if (result.Contains("#A2"))
           return Unauthorized("Password or gmail is incorrect");


       return Ok(new { token = result});
    }
}