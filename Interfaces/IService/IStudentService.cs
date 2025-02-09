using StudentManagement.Dtos.Student;
using StudentManagement.Helper;
using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface IStudentService
{
    Task<Student?> AddStudentAsync(CreateToStudentDto createToStudentDto);
    Task<List<Student>?> GetStudentsAsync(QueryObjectStudent query);

    Task<Student?> UpdateStudentAsync(UpdateStudentDto updateStudentDto, string studentNumber);

    Task<Student?> DeleteStudentAsync(string studentNumber);

    Task<bool> checkClaimAsync();
}