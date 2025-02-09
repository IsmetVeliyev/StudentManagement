using StudentManagement.Dtos.Course;
using StudentManagement.Models;

namespace StudentManagement.Dtos.Student;

public class GetStudentDto
{
    public string studentNum { get ; set; }=null!;
    public string studentName { get; set; } = null!;
    
    public int age { get; set; }

    public DateTime RegistrationDate { get; set; } =  DateTime.Now;

    public List<StudentCoursesDto> courses { get; set; }
    
}