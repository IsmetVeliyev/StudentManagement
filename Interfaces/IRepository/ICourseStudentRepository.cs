using StudentManagement.Models;
using StudentManagement.Repository;

namespace StudentManagement.Interfaces;

public interface ICourseStudentRepository
{
    Task<CourseStudent> CreateAsync(CourseStudent courseStudent);
    Task<CourseStudent> DeleteCourseStudentAsync(CourseStudent courseStudent);
}