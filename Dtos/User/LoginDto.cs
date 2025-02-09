using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dtos.User;

public class LoginDto
{
    [Required] 
    public string gmail { get; set; }
    [Required] public string password { get; set; }
}