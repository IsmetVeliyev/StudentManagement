using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers;
[Route("management/Student")]
public class StudentDeleteController: ControllerBase
{
    private readonly IStudentService _studentServ;

    public StudentDeleteController(IStudentService studentServ)
    {
        _studentServ = studentServ;
    }


    [HttpDelete]
    [Route("/DeleteStudent{studentNumber}")]
    [Authorize]
    
    public async Task<IActionResult> StudentDelete([FromRoute]string studentNumber)
    {
        var result = await _studentServ.checkClaimAsync();
        var student = await _studentServ.DeleteStudentAsync(studentNumber);
        return Ok("Deleted");
    }

    
}