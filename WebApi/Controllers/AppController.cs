using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppController : ControllerBase
{
    // GET: api/App
    [HttpGet]
    public IActionResult GetAppStatus()
    {
        return Ok(new { Message = "API is running." });
    }

    // GET: api/App/auth
    [HttpGet("auth")]
    [Authorize(Policy = "ApiPolicy")]
    public IActionResult GetAppStatusAndCheckAuth()
    {
        return Ok(new { Message = "API is running and you are authorized." });
    }
}
