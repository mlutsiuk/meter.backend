using System.Data.Entity;
using Meter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("users")]
public class UsersController : ControllerBase
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
        return _context.Users.ToList();
    }

    // [Route("{id}")]
    // [HttpPost]
    // public async Task<User?> Store(int id)
    // {
    //     
    // }
    
    [Route("{id}")]
    [HttpGet]
    public async Task<User?> Show(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}