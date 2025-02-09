using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;
using StudentManagement.Mappers;

namespace StudentManagement.Controllers.CourseController;
[Route("management/Course")]
public class CourseGetController:ControllerBase
{
    private readonly ICourseService _courseServ;

    public CourseGetController(ICourseService courseServ)
    {
        _courseServ = courseServ;
    }

    [HttpGet]
    [Route("/GetCourses")]
    [Authorize]
    public async Task<IActionResult> GetCourses()
    {
        await  _courseServ.checkClaimAsync();
        var courses = await _courseServ.GetCoursesAsync();
        var coursesDto = courses.Select(c => c.GetDto()).ToList();
        return Ok(coursesDto);
    }

}