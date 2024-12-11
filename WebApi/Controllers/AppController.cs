using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAppStatus()
    {
        return Ok(new { Message = "API is running." });
    }
}
