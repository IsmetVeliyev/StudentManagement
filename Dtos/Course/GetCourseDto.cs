namespace StudentManagement.Dtos.Course;

public class GetCourseDto
{
    public int LessonId { get; set; }
    public string teacherpassaportNumber { get; set; } = null!;
    public string LessonName { get; set; } = null!;
    public double Hours { get; set; }
    public double Fee { get; set; }
}