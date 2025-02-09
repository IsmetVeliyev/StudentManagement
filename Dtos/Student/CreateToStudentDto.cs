using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dtos.Student;

public class CreateToStudentDto
{
    [Required]
    [MaxLength(10,ErrorMessage = "Number length cannot be higher than 10 and lower than 8")]
    [MinLength(8,ErrorMessage="Number length cannot be higher than 10 and lower than 8")]
    public string studentNum { get; set; }=null!;

    [Required]
    public string studentName { get; set; } = null!;
    [Required]
    [Range(18,30)]
    public int age { get; set; }
}