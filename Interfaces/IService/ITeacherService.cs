using StudentManagement.Dtos.Teacher;
using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface ITeacherService
{
    Task<Teacher?> AddTeacherAsync(CreateToTeacherDto createToTeacherDto);
    Task<List<Teacher>?> GetTeachersAsync();

    Task<Teacher?> UpdateTeachersAsync(UpdateTeacherDto updateTeacherDto, string passportNumber);

    Task<Teacher?> DeleteTeacherAsync(string passportNumber);
    
    Task<bool> checkClaimAsync();
}