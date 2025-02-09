using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.TeacherController;
[Route("management/Teacher")]
public class TeacherDeleteController : ControllerBase
{
    private readonly ITeacherService _teacherServ;

    public TeacherDeleteController(ITeacherService teacherServ,IValidationService validationServ)
    {
        _teacherServ = teacherServ;
    }

    [HttpDelete]
    [Route("/DeleteTeacher{passportNumber}")]
    [Authorize]

    public async Task<IActionResult> DeleteTeacher([FromRoute]string passportNumber)
    {
        
        var result = await _teacherServ.checkClaimAsync();
        var teacher = await _teacherServ.DeleteTeacherAsync(passportNumber);
        return Ok("Deleted");
    }
    
}