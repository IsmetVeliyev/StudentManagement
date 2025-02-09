using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.Teacher;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.TeacherController;
[Route("management/Teacher")]
public class TeacherAddController : ControllerBase
{
    private readonly ITeacherService _teacherServ;
    public TeacherAddController(ITeacherService teacherServ, IValidationService validationServ)
    {
        _teacherServ = teacherServ;
    }

    [HttpPost]
    [Route("/AddTeacher")]
    [Authorize]

    public async Task<IActionResult> AddTeacher([FromBody] CreateToTeacherDto createToTeacherDto)
    {
        try
        {
            var result = await _teacherServ.checkClaimAsync();
            var teacher = await _teacherServ.AddTeacherAsync(createToTeacherDto);
            return Ok("Completed");
        }
        catch (Exception e){
            return BadRequest(e);
        }

    }

    }