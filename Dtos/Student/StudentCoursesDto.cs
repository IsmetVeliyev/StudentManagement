namespace StudentManagement.Dtos.Student
{
    public class StudentCoursesDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; } = null!;
        public double Hours { get; set; }
        public double Fee { get; set; }
    }
}

