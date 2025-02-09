using Microsoft.EntityFrameworkCore;
using StudentManagement.Context;
using StudentManagement.Dtos.Course;
using StudentManagement.Exceptions;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Repository;


public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Course> CreateAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();

        return course;
    }

    public async Task<Course> GetByIdAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        return course;
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        var course = await _context.Courses.ToListAsync();
        return course;
    }


    public async Task<Course> UpdateCourseAsync(UpdateCourseDto updateCourseDto, int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
            throw new NotFoundException("Not found");
        course.Fee = updateCourseDto.Fee;
        course.Hours = updateCourseDto.Hours;
        course.LessonName = updateCourseDto.LessonName;
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<Course> DeleteCourseAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
            throw new NotFoundException("Not found");
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return course;

    }

    public async Task<Course> FindByLesson(string lesson)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c=>c.LessonName==lesson);
        return course;
    }
    
}