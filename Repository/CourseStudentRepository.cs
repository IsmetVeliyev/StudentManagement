using System.ComponentModel.Design;
using StudentManagement.Context;
using StudentManagement.Interfaces;
using StudentManagement.Models;
namespace StudentManagement.Repository;


public class CourseStudentRepository : ICourseStudentRepository
{
   private readonly ApplicationDbContext _context;

   public CourseStudentRepository(ApplicationDbContext context)
   {
      _context = context;
   }
   
   public async Task<CourseStudent> CreateAsync(CourseStudent courseStudent)
   {

      var student = await _context.Students.FindAsync(courseStudent.StudenNumber);
      if (student == null)
         throw new Exception("Student Not found");
      var course = await _context.Courses.FindAsync(courseStudent.CourseId);
      if (course == null)
         throw new Exception("Course Not Found");
      await _context.CoursesStudents.AddAsync(courseStudent);
      await _context.SaveChangesAsync();

      return courseStudent;
   }

   public async Task<CourseStudent> DeleteCourseStudentAsync(CourseStudent courseStudent)
   {
      var student = await _context.Students.FindAsync(courseStudent.StudenNumber);
      if (student == null)
         throw new Exception("Student Not found");
      
      var lessoniId = await _context.CoursesStudents.FindAsync(courseStudent.StudenNumber);

      if (lessoniId.CourseId == courseStudent.CourseId)
      {
         _context.CoursesStudents.Remove(courseStudent);
         await _context.SaveChangesAsync();
      }

      return courseStudent;
      

   }
   
}