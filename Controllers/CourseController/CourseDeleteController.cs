using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.CourseController;
[Route("management/Course")]
public class CourseDeleteController:ControllerBase
{
    private readonly ICourseService _courseServ;

    public CourseDeleteController(ICourseService courseServ)
    {
        _courseServ = courseServ;
    }

    [HttpDelete]
    [Route("/DeleteLesson{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteLesson([FromRoute]int lessonId)
    {
       await _courseServ.checkClaimAsync();
       var course=await _courseServ.DeleteCourseAsync(lessonId);
       return Ok(course);
    }
    
    
}