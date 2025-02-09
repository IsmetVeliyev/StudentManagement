using Microsoft.EntityFrameworkCore;
using StudentManagement.Context;
using StudentManagement.Dtos.Teacher;
using StudentManagement.Exceptions;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Repository;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _context;

    public TeacherRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Teacher?> CreateAsync(Teacher teacher)
    {
        
        try
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

        }
        catch (Exception e)
        {
            Console.Write(e);
            return null;
        }

        return teacher;
    }

    public async Task<Teacher?> GetByNumAsync(string pasNumber)
    { 
        var teacher = await _context.Teachers.FindAsync(pasNumber);
        return teacher;
    }

    public async Task<List<Teacher>?> GetAllTeachersAsync()
    {
        var teachers = await _context.Teachers.ToListAsync();
        return teachers;

    }

    public async Task<Teacher?> UpdateTeacherAsync(UpdateTeacherDto updateTeacherDto, string pastNumber)
    {
        var teacher = await _context.Teachers.FindAsync(pastNumber);
        if (teacher == null)
            throw new Exception("There is not registration int his num");
        teacher.name = updateTeacherDto.name;
        teacher.field = updateTeacherDto.field;
        teacher.salary = updateTeacherDto.salary;
        await _context.SaveChangesAsync();
        return teacher;
    }

    public async Task<Teacher?> DeleteTeacherAsync(string pastNumber)
    {
        var teacher = await _context.Teachers.FindAsync(pastNumber);
        if (teacher == null)
            throw new NotFoundException("There is not registration int his num");
        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
        return teacher;
    }
}