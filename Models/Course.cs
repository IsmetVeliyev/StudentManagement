using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models;
[Table("Courses")]
public class Course
{

    [Key] public int LessonId { get; set; }
    public string LessonName { get; set; } = null!;
    public double Hours { get; set; }
    public double Fee { get; set; }
    public string teacherpassaportNumber { get; set; } = null!;
    public Teacher teacher { get; set; }

    public List<CourseStudent> StudentCourses { get; set; } = new List<CourseStudent>();


}