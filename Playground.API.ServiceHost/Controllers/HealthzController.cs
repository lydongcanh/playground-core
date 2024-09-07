using Microsoft.AspNetCore.Mvc;

namespace Playground.API.ServiceHost.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthzController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}