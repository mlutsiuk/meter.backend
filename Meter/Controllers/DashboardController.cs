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
        return Json(await _dashboardRepository.My());
    }
    
    // [Route("shared")]
    // [HttpGet]
    // public IActionResult Shared()
    // {
    //     
    // }
    
    
}