using StudentManagement.Dtos.Course;
using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface ICourseRepository
{
    Task<Course> CreateAsync(Course course);
    Task<Course> GetByIdAsync(int id);
    Task<List<Course>> GetAllCoursesAsync();
    Task<Course> UpdateCourseAsync(UpdateCourseDto updateCourseDto , int id);
    Task<Course> DeleteCourseAsync(int id);

    Task<Course> FindByLesson(string lesson);
}