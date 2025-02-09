using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models;

[Table("Teachers")]
public class Teacher
{
    [Key] public string passaportNumber { get; set; } = null!;
    public string name { get; set; } = null!;
    public string field { get; set; } = null!;
    public string salary { get; set; } = null!;

    private List<Teacher> Teachers
    {
        get;
        set;
    } = new List<Teacher>();
}