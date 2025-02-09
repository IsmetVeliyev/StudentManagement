using StudentManagement.Dtos.Student;
using StudentManagement.Helper;
using StudentManagement.Models;
using System.Globalization;

namespace StudentManagement.Interfaces;

public interface IStudentRepository
{
     Task<Student> CreateAsync(Student student);
     Task<Student> GetByNumAsync(string stuNumber);
     Task<List<Student>> GetAllStudentsAsync(QueryObjectStudent query);

     Task<Student> UpdateStudentAsync(UpdateStudentDto updateStudentDto,string studentNumber);

     Task<Student> DeleteStudentAsync(string studentNumber);
}