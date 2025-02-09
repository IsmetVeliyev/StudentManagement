using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.Course;
using StudentManagement.Dtos.Student;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.CourseController;
[Route("management/Course")]
public class CourseAddController:ControllerBase
{
    private readonly ICourseService _courseServ;

    public CourseAddController(ICourseService courseServ)
    {
        _courseServ = courseServ;
    }

    [HttpPost]
    [Route("/AddLesson")]
    [Authorize]

    public async Task<IActionResult> AddLesson([FromBody]CreateToCourseDto createToCourseDto)
    {
        await _courseServ.checkClaimAsync();
        var course = await _courseServ.AddCourseAsync(createToCourseDto);
        
        return Ok(course);
    }
    
    
}