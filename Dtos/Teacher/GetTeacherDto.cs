namespace StudentManagement.Dtos.Teacher;

public class GetTeacherDto
{ 
    public string passaportNumber { get; set; } = null!;
    public string name { get; set; } = null!;
    public string field { get; set; } = null!;
    public string salary { get; set; } = null!;
}
