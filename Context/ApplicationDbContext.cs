using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Context;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseStudent>()
            .HasKey(cs => new { cs.CourseId, cs.StudenNumber });

        modelBuilder.Entity<CourseStudent>()
            .HasOne(cs => cs.course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(cs => cs.CourseId);

        modelBuilder.Entity<CourseStudent>()
            .HasOne(cs => cs.student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(cs => cs.StudenNumber);
    }
    public DbSet<User> Users
    {
        get;
        set;
    }

    public DbSet<Student> Students
    {
        get;
        set;
    }

    public DbSet<Teacher> Teachers
    {
        get;
        set;
    }

    public DbSet<Course> Courses
    {
        get;
        set;
    }

    public DbSet<CourseStudent> CoursesStudents
    {
        get;
        set;
    }
}