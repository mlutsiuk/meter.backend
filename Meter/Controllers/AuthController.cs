using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

public class AuthController : ControllerBase
{
    [Route("auth/google/redirect")]
    [HttpGet]
    public RedirectResult GoogleRedirect()
    {
        return Redirect("");
    }

    [Route("auth/google/callback")]
    [HttpGet]
    public string GoogleCallback()
    {
        return "Google callback";
    }
}