using Meter.Models;
using Meter.Requests.User;
using Microsoft.EntityFrameworkCore;

namespace Meter.Repositories;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> All()
    {
        return await _context.Users.Include(user => user.Role).ToListAsync();
    }

    public async Task<User?> Find(int id)
    {
        return await _context.Users.Include(user => user.Role).FirstOrDefaultAsync(u => u.Id == id);
    }

    // public async Task<User> Update(int id, UserUpdateRequest request)
    // {
    //     var user = await _context.Users.FindAsync(id);
    //
    //     user.Role = await _context.Roles.FindAsync(request.RoleId);
    // }
}