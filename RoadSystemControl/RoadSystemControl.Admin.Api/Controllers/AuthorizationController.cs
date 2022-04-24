using Microsoft.AspNetCore.Mvc;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;

namespace RoadSystemControl.Admin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService _service;

    public AuthorizationController(IAuthorizationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] AuthDto dto) => Ok(await _service.SignIn(dto));
}