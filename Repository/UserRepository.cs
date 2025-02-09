using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Context;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<User> GetByIdAsync(string gmail)
    {
        var  user=await _context.Users.FirstOrDefaultAsync(x => x.gmail == gmail);
        return user;
    }
}