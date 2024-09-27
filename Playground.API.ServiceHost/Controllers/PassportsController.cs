using Microsoft.AspNetCore.Mvc;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.ServiceHost.Controllers;

[ApiController]
[Route("[controller]")]
public class PassportsController(IPassportService passportService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePassportAsync(CreatePassportRequest request, CancellationToken cancellationToken)
    {
        var passport = await passportService.CreatePassportAsync(request, cancellationToken);
        return Ok(passport);
    }
}