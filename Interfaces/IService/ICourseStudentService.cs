using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface ICourseStudentService
{
    Task<CourseStudent> createCourseStudent(string studentNum,int lessonId);
    Task<CourseStudent> deleteCourseStudent(string studentNum,int lessonId);

     Task<bool> checkClaimAsync();


}