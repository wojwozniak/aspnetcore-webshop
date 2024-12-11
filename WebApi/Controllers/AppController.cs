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
}
