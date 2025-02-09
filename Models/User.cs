using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Models;

[Table("Users")]
public class User
{
    [Key] 
    public string gmail { get; set; } = null!;
    public string password { get; set; } = null!;
    public string role { get; set; } = null!;
}