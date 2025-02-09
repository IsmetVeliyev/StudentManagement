using System.Globalization;
using System.Web.WebPages.Html;
using Microsoft.EntityFrameworkCore.Query.Internal;
using StudentManagement.Dtos.Student;
using StudentManagement.Exceptions;
using StudentManagement.Interfaces;
using StudentManagement.Mappers;
using StudentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Helper;

namespace StudentManagement.Services;

public class StudentService :IStudentService
{
    private readonly IStudentRepository _studentRepo;
    private readonly IValidationService _validationServ;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public StudentService(IStudentRepository studentRepo,IValidationService validationServ,IHttpContextAccessor httpContextAccessor)
    {
        _studentRepo = studentRepo;
        _validationServ = validationServ;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Student?> AddStudentAsync(CreateToStudentDto createToStudentDto)
    {
           var student = await _studentRepo.GetByNumAsync(createToStudentDto.studentNum);
            if (student != null!)
                throw new NotFoundException("There is studentNumber in this format");

            student = StudentMappers.CreateToStudent(createToStudentDto);
            await _studentRepo.CreateAsync(student);
        
       
       return student;
    }

    public async Task<List<Student>?> GetStudentsAsync(QueryObjectStudent query)
    {
        var  students = await _studentRepo.GetAllStudentsAsync(query);
        return students;
    }

    public async Task<Student?> UpdateStudentAsync(UpdateStudentDto updateStudentDto,string studentNumber)
    { 
        var student = await _studentRepo.UpdateStudentAsync(updateStudentDto, studentNumber);
        return student;
    }

    public async Task<Student?> DeleteStudentAsync(string studentNumber)
    {
        var  student = await _studentRepo.DeleteStudentAsync(studentNumber);
        return student;
    }

    public async Task<bool> checkClaimAsync()
    {
        var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
        var result = await _validationServ.validatedRequestValues(authHeader);
        if (!result)
            throw new UnauthorizedAccessException("Not Permission for this role");
        return true;
        
    }
}