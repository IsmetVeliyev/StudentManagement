using StudentManagement.Dtos.Student;
using StudentManagement.Models;
using System.Runtime.CompilerServices;

namespace StudentManagement.Mappers;

public static class StudentMappers
{
    public static Student CreateToStudent(CreateToStudentDto createToStudentDto)
    {
        return new Student
        {
            studentNum = createToStudentDto.studentNum,
            studentName = createToStudentDto.studentName,
            age = createToStudentDto.age,
        };
    }

    public static GetStudentDto StudentToStudentDto(this Student student)
    {
        return new()
        {
            studentNum = student.studentNum,
            studentName = student.studentName,
            age = student.age,
            RegistrationDate = student.RegistrationDate,
            courses = student.StudentCourses.Select(s => s.StudentCoursesDto()).ToList(),
        };
    }
    public static StudentCoursesDto StudentCoursesDto(this CourseStudent course)
    {
        return new()
        {
            LessonId = course.course.LessonId,
            LessonName = course.course.LessonName,
            Fee = course.course.Fee,
            Hours = course.course.Hours,
        };
    }
}

