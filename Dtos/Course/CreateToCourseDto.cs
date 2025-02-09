namespace StudentManagement.Dtos.Course;

public class CreateToCourseDto
{
    public string teacherpassaportNumber { get; set; } = null!;
    public string LessonName { get; set; } = null!;
    public double Hours { get; set; }
    public double Fee { get; set; }
    
}