using StudentManagement.Dtos.Course;
using StudentManagement.Interfaces;
using StudentManagement.Mappers;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class CourseService :ICourseService
{
    private readonly ICourseRepository _courseRepo;
    private readonly IValidationService _validationServ;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CourseService(ICourseRepository courseRepo,IValidationService validationServ,IHttpContextAccessor httpContextAccessor)
    {
        _courseRepo = courseRepo;
        _validationServ=validationServ;
        _httpContextAccessor=httpContextAccessor;

    }
    
    public async Task<Course?> AddCourseAsync(CreateToCourseDto createToCourseDto)
    {
        Course course = CourseMappers.CreateDtoToCourse(createToCourseDto);
        course = await _courseRepo.CreateAsync(course);
        return course;

    }

    public async Task<List<Course>?> GetCoursesAsync()
    {
        var courses =  await _courseRepo.GetAllCoursesAsync();
        return courses;
    }

    public async Task<Course?> UpdateCourseAsync(UpdateCourseDto updateCourseDto, int id)
    {
        var course = await _courseRepo.UpdateCourseAsync(updateCourseDto, id);
        return course;
    }

    public async Task<Course?> DeleteCourseAsync(int id)
    {
        var course = await _courseRepo.DeleteCourseAsync(id);
        return course;
    }

    
    public async Task<bool> checkClaimAsync()
    {
        var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
        var result = await _validationServ.validatedRequestValues(authHeader);
        if (!result)
            throw new UnauthorizedAccessException("Not Permission for this role");
        return true;
        
    }
}