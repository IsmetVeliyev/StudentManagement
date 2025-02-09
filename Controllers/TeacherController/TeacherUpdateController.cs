using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.Teacher;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.TeacherController;
[Route("management/Teacher")]
public class TeacherUpdateController:ControllerBase
{
    private readonly ITeacherService _teacherServ;

    public TeacherUpdateController(ITeacherService teacherServ)
    {
        _teacherServ = teacherServ;
    }

    [HttpPut]
    [Route("/UpdateTeacher{passportNumber}")]
    [Authorize]

    public async Task<IActionResult> updateTeacher([FromRoute]string passportNumber,[FromBody] UpdateTeacherDto updateTeacherDto)
    {
        await _teacherServ.checkClaimAsync();
        var result = await _teacherServ.checkClaimAsync();
        var teacher = await _teacherServ.UpdateTeachersAsync(updateTeacherDto,passportNumber);
        return Ok("Updated");
    }

}