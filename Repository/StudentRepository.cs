using Microsoft.EntityFrameworkCore;
using StudentManagement.Context;
using StudentManagement.Dtos.Student;
using StudentManagement.Exceptions;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Helper;

namespace StudentManagement.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Student> CreateAsync(Student student)
    {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

        return student;
    }

   public async Task<Student> GetByNumAsync(string stuNumber)
   {
       var student = await _context.Students.FindAsync(stuNumber);
       return student;
   }

   public async Task<List<Student>> GetAllStudentsAsync(QueryObjectStudent query)
   {
       var students =  _context.Students.Include(s => s.StudentCourses).ThenInclude(sc => sc.course).AsQueryable();
        if (!string.IsNullOrEmpty(query.Name))
        {
            students = students.OrderBy(s => s.studentName);
        }
        if (!string.IsNullOrWhiteSpace(query.YasLower)){
            students = students.Where(students => students.age > Int32.Parse(query.YasLower));
        }
        if (!string.IsNullOrWhiteSpace(query.YasLower))
        {
            students = students.Where(students => students.age < Int32.Parse(query.YasLower));

        }
       return students.ToList();
   }
   

   public async Task<Student> UpdateStudentAsync(UpdateStudentDto updateStudentDto,string studentNumber)
   {
       
       var student = await _context.Students.FindAsync(studentNumber);

       if (student == null)
           throw new NotFoundException("Not registration in this num");

       student.studentName = updateStudentDto.studentName;
       student.age = updateStudentDto.age;

       await _context.SaveChangesAsync();
       return student;
   }

   public async Task<Student> DeleteStudentAsync(string studentNumber)
   {
       var student = await _context.Students.FindAsync(studentNumber);
       if (student == null)
           throw new NotFoundException("Not registration in this num");
       _context.Students.Remove(student);
       await _context.SaveChangesAsync();
       return student;
   }

}
