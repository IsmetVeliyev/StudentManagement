using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.CourseStudent;
[Route("management/Course")]
public class CourseStudentDeleteController:ControllerBase
{
    private readonly ICourseStudentService _courseStudentServ;

    public CourseStudentDeleteController(ICourseStudentService courseStudentServ )
    {
        _courseStudentServ = courseStudentServ;
    }

    [HttpDelete] [Route("/addCourseStudent/{studentNum}/{lessonid}")]
    [Authorize]
    public async Task<IActionResult> deleteStudentCourse([FromRoute]string studentNum,[FromRoute]int lesssonId)
    {
       await _courseStudentServ.checkClaimAsync();
       var courseStudent = _courseStudentServ.deleteCourseStudent(studentNum, lesssonId);
       return Ok(courseStudent);
    }
}