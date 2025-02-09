using StudentManagement.Dtos.Course;
using StudentManagement.Models;

namespace StudentManagement.Mappers;

public static class CourseMappers
{
    public static Course CreateDtoToCourse(CreateToCourseDto createToCourseDto)
    {
        return new Course
        {
            teacherpassaportNumber = createToCourseDto.teacherpassaportNumber,
            LessonName = createToCourseDto.LessonName,
            Fee = createToCourseDto.Fee,
            Hours = createToCourseDto.Hours,
            
        };
    }

    public static GetCourseDto GetDto(this Course course)
    {
        return new GetCourseDto
        {
            LessonId = course.LessonId,
            LessonName = course.LessonName,
            Hours = course.Hours,
            Fee = course.Fee,
            teacherpassaportNumber = course.teacherpassaportNumber
        };
    }
}
