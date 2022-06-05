using Meter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meter.Controllers;

[Route("users")]
[Authorize]
public class UsersController : Controller
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [Route("")]
    [HttpGet]
    public List<User> Index()
    {
        return _context.Users.Include(user => user.Role).ToList();
    }

    // [Route("{id}")]
    // [HttpPost]
    // public async Task<User?> Store(int id)
    // {
    //     
    // }

    [Route("{id}")]
    [HttpGet]
    public async Task<User?> Show(int id)    // TODO: 404 on null
    {
        return await _context.Users.Include(user => user.Role).FirstOrDefaultAsync(u => u.Id == id);
    }
}