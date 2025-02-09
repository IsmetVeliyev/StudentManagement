using StudentManagement.Dtos.Teacher;
using StudentManagement.Interfaces;
using StudentManagement.Mappers;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepo;
    private readonly IValidationService _validationServ;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TeacherService(ITeacherRepository teacherRepo,IValidationService validationServ,IHttpContextAccessor httpContextAccessor)
    {
        _teacherRepo = teacherRepo;
        _validationServ = validationServ;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<Teacher?> AddTeacherAsync(CreateToTeacherDto createToTeacherDto)
    {

           var  teacher = await _teacherRepo.GetByNumAsync(createToTeacherDto.passaportNumber);
            /*if (teacher != null)
                return null!;*/
            teacher = TeacherMappers.TeacherDtoToTeacher(createToTeacherDto);
            await _teacherRepo.CreateAsync(teacher);
            
        return teacher;

    }

    public async Task<List<Teacher>?> GetTeachersAsync()
    {
        
        var teachers = await _teacherRepo.GetAllTeachersAsync();
        return teachers;
    }

    public async Task<Teacher?> UpdateTeachersAsync(UpdateTeacherDto updateTeacherDto, string passportNumber)
    {
        var teacher = await _teacherRepo.UpdateTeacherAsync(updateTeacherDto, passportNumber);
        return teacher;
    }

    public async Task<Teacher?> DeleteTeacherAsync(string passportNumber)
    {

        var teacher = await _teacherRepo.DeleteTeacherAsync(passportNumber);
        return teacher;

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