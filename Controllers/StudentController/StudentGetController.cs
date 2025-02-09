using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Helper;
using StudentManagement.Interfaces;
using StudentManagement.Mappers;
using System.Text.Json;
namespace StudentManagement.Controllers;
[Route("management/Student")]
public class StudentGetController:ControllerBase
{
    private readonly IStudentService _studentServ;

    public StudentGetController(IStudentService studentServ,IValidationService validationServ)
    {
        _studentServ = studentServ;
    }

    [HttpGet]
    [Route("/Students")]
   // [Authorize]
    public async Task<IActionResult> GetStudents([FromQuery] QueryObjectStudent query)
    {
       // var result = await _studentServ.checkClaimAsync();
        var students = await _studentServ.GetStudentsAsync(query);
        var studentsDto = students.Select(s => s.StudentToStudentDto()).ToList();
        return Ok(studentsDto);
    }
}