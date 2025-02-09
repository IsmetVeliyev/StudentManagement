using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StudentManagement.Dtos.Course;
using StudentManagement.Interfaces;

namespace StudentManagement.Controllers.CourseController;
[Route("management/Course")]
public class CourseUpdateController:ControllerBase
{
    private readonly ICourseService _courseServ;

    public CourseUpdateController(ICourseService courseServ)
    {
        _courseServ = courseServ;
    }


    [HttpPut]
    [Route("/UpdateCourse{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateCourse([FromRoute]int lessonId ,[FromBody]UpdateCourseDto updateCourseDto)
    {
        await _courseServ.checkClaimAsync();
        var course = _courseServ.UpdateCourseAsync(updateCourseDto, lessonId);
        return Ok(course);
    }
    
    
}