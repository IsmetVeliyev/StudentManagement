using StudentManagement.Dtos.Teacher;
using StudentManagement.Models;

namespace StudentManagement.Mappers;

public static class TeacherMappers
{
    public static Teacher TeacherDtoToTeacher(CreateToTeacherDto createToTeacherDto)
    {
        return new Teacher
        {
            passaportNumber = createToTeacherDto.passaportNumber,
            name = createToTeacherDto.name,
            field = createToTeacherDto.field,
            salary = createToTeacherDto.salary

        };
    }

    public static GetTeacherDto TeacherToTeacherDto(this Teacher teacher)
    {
        return new GetTeacherDto
        {
            passaportNumber = teacher.passaportNumber,
            name = teacher.passaportNumber,
            field = teacher.field,
            salary = teacher.salary,
        };
    }
}