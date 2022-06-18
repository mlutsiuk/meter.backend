using System.Security.Claims;
using Meter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("dashboard")]
[Authorize]
public class Dashboard : Controller
{
    private readonly DashboardRepository _dashboardRepository;

    public Dashboard(DashboardRepository dashboardRepository)
    {
        _dashboardRepository = dashboardRepository;
    }

    [Route("my")]
    [HttpGet]
    public async Task<IActionResult> My()
    {
        string userIdString = User.Claims
            .ToList()
            .First(x => x.Type.Equals(ClaimTypes.Name))
            .Value;
        int userId = int.Parse(userIdString);
        
        return Json(await _dashboardRepository.My(userId));
    }
    
    // [Route("shared")]
    // [HttpGet]
    // public IActionResult Shared()
    // {
    //     
    // }
    
    
}