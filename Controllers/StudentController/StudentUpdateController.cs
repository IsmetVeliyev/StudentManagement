using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.Student;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Controllers;
[Route("management/Student")]
public class StudentUpdateController :ControllerBase
{

    private readonly IStudentService _studentServ;
    public StudentUpdateController(IStudentService studentServ,IValidationService validationServ)
    {
        _studentServ = studentServ;
    }

    [HttpPut]
    [Route("/UpdateStudent{studentNumber}")]
    [Authorize]
    public async Task<IActionResult> updateStudent(
        [FromRoute] string studentNumber,[FromBody] UpdateStudentDto updateStudentDto)
    {
        var result = await _studentServ.checkClaimAsync();
        var student = await _studentServ.UpdateStudentAsync(updateStudentDto, studentNumber);
        return Ok("Updated");
    }

}