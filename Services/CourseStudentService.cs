using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class CourseStudentService : ICourseStudentService
{
    public ICourseStudentRepository _courseStudentRepository;
    private readonly IValidationService _validationServ;
    private readonly IHttpContextAccessor _httpContextAccessor;
    

    public CourseStudentService(ICourseStudentRepository courseStudentRepository,IValidationService validationServ,IHttpContextAccessor httpContextAccessor)
    {
        _courseStudentRepository = courseStudentRepository;
        _validationServ = validationServ;
        _httpContextAccessor = httpContextAccessor;

    }
    

    public async Task<CourseStudent> createCourseStudent(string studentNum,int lessonId)
    {
        var studentCourseModel = new CourseStudent();
        studentCourseModel.CourseId = lessonId;
        studentCourseModel.StudenNumber = studentNum;
   

        var studentCourse = await _courseStudentRepository.CreateAsync(studentCourseModel);
       
        return studentCourse;
    }

    public async Task<CourseStudent> deleteCourseStudent(string studentNum, int lessonId)
    {
        CourseStudent studentCourseModel = new CourseStudent
        {
            StudenNumber = studentNum,
            CourseId = lessonId

        };

        var studentCourse = await _courseStudentRepository.DeleteCourseStudentAsync(studentCourseModel);

        return studentCourse;
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