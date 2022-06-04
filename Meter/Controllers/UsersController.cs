using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Meter.Auth;
using Meter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtAuthOptions _jwtAuthOptions;

    public UsersController(AppDbContext context, JwtAuthOptions jwtAuthOptions)
    {
        _context = context;
        _jwtAuthOptions = jwtAuthOptions;
    }

    [Route("")]
    [HttpGet]
    public List<User> Index()
    {
        return _context.Users.ToList();
    }

    [Route("login/{username}")]
    [HttpGet]
    public string Login(string username)
    {
        var claims = new List<Claim> {new(ClaimTypes.Name, username)};
        
        var jwt = new JwtSecurityToken(
            issuer: _jwtAuthOptions.Issuer,
            audience: _jwtAuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: _jwtAuthOptions.GetSigningCredentials());

        return new JwtSecurityTokenHandler().WriteToken(jwt);
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