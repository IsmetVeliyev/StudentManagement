using StudentManagement.Dtos.Teacher;
using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface ITeacherRepository
{
    
    Task<Teacher?> CreateAsync(Teacher teacher);
    Task<Teacher?> GetByNumAsync(string pasNumber);
    Task<List<Teacher>?> GetAllTeachersAsync();

    Task<Teacher?> UpdateTeacherAsync(UpdateTeacherDto updateTeacherDto,string pastNumber);

    Task<Teacher?> DeleteTeacherAsync(string pastNumber);
    
}