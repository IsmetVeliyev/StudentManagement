using StudentManagement.Dtos.Course;
using StudentManagement.Dtos.Student;
using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface ICourseService
{
    Task<Course?> AddCourseAsync(CreateToCourseDto createToCourseDto);
    Task<List<Course>?> GetCoursesAsync();

    Task<Course?> UpdateCourseAsync(UpdateCourseDto updateCourseDto, int id);

    Task<Course?> DeleteCourseAsync(int id);
     Task<bool> checkClaimAsync();
    
}