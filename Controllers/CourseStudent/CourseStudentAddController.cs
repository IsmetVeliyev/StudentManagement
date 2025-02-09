using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.CourseStudent;
[Route("management/Course")]
public class CourseStudentAddController :ControllerBase
{
    private readonly ICourseStudentService _courseStudentServ;

    public CourseStudentAddController(ICourseStudentService courseStudentServ )
    {
        _courseStudentServ = courseStudentServ;
    }
    
    [HttpGet]
    [Route("/addCourseStudent/{studentNum}/{lessonId}")]
    [Authorize]
    public async Task<IActionResult> addStudentCourse([FromRoute]string studentNum ,[FromRoute]int lessonId)
    {
        await _courseStudentServ.checkClaimAsync();
        var sc = await _courseStudentServ.createCourseStudent(studentNum, lessonId);
        return Ok("Added");
    }
}