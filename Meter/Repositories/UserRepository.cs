using AutoMapper;
using Meter.Dtos;
using Meter.Models;
using Microsoft.EntityFrameworkCore;

namespace Meter.Repositories;

public class UserRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> All()
    {
        return _mapper.Map<IEnumerable<UserDto>>(await _context.Users
            .Include(user => user.Role)
            .ToListAsync()
        );
    }

    public async Task<UserDto?> Find(int id)
    {
        return _mapper.Map<UserDto>(await _context.Users
            .Include(user => user.Role)
            .FirstOrDefaultAsync(u => u.Id == id)
        );
    }

    public async Task<UserDto?> FindByCredentials(string email, string password)
    {
        return _mapper.Map<UserDto>(await _context.Users
            .Include(user => user.Role)
            .FirstOrDefaultAsync(user => user.Email == email && user.Password == password)
        );
    }

    // public async Task<User> Update(int id, UserUpdateRequest request)
    // {
    //     var user = await _context.Users.FindAsync(id);
    //
    //     user.Role = await _context.Roles.FindAsync(request.RoleId);
    // }
}