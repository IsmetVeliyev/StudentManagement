using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models;
[Keyless]
[Table("CourseStudents")]
public class CourseStudent
{
    public string StudenNumber { get; set; } = null!;
    public Student student { get; set; }
    public int CourseId { get; set; }
    public Course course { get; set; }
}