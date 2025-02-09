using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models;
[Table("Students")]
public class Student
{
    
    [Key]
    public string studentNum { get; set; }=null!;
    public string studentName { get; set; } = null!;
    
    public int age { get; set; }

    public DateTime RegistrationDate { get; set; } =  DateTime.Now;
    
    public List<CourseStudent> StudentCourses { get; set; } = new List<CourseStudent>();

}