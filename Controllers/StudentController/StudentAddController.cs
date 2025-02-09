using System.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.Student;
using StudentManagement.Interfaces;
using StudentManagement.Mappers;
using StudentManagement.Models;

namespace StudentManagement.Controllers;
[Route("management/Student")]
public class StudentAddController:ControllerBase
{
    private readonly IStudentService _studentServ;
    private readonly IValidationService _validationServ;
    public StudentAddController(IStudentService studentServ,IValidationService validationServ)
    {
        _studentServ = studentServ;
        _validationServ = validationServ;
    }
    [HttpPost]
    [Route("/RegisterStudent")]
    [Authorize]
    public async Task<IActionResult> AddStudent([FromBody]CreateToStudentDto createToStudentDto)
    { 
        var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        var result = await _validationServ.validatedRequestValues(authHeader);
        if (!result)
            return Unauthorized("not permission");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var student = await _studentServ.AddStudentAsync(createToStudentDto);

        return Ok("Completed");

    }
}