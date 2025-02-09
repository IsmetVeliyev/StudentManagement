using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;
using StudentManagement.Mappers;
using StudentManagement.Models;
namespace StudentManagement.Controllers.TeacherController;
[Route("management/Teacher")]
public class TeacherGetController :ControllerBase
{
    private readonly ITeacherService _teacherService;
    public TeacherGetController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    [Route("/GetTeachers")]
    [Authorize]
    public async Task<IActionResult> getAllTeachers()
    {
    //    try{
        await _teacherService.checkClaimAsync();
        var teachers = await _teacherService.GetTeachersAsync();
        var teachersDto = teachers.Select(t => t.TeacherToTeacherDto()).ToList();
        return Ok(teachersDto);
    //    }
    //    catch(Exception e){
          //  return BadRequest(e);
      //  }
    }
    
}