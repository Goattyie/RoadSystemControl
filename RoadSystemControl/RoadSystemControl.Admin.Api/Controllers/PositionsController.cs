using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoadSystemControl.Admin.Api.Core;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Enums;

namespace RoadSystemControl.Admin.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly IPositionService _service;

    public PositionsController(IPositionService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

    [AuthorizeRole(UserRole.Operator, UserRole.Admin)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PositionCreateDto dto)
    {
        var createdDto = await _service.AddRangeAsync(dto);

        return Ok(createdDto.First());
    }

    [AuthorizeRole(UserRole.Operator, UserRole.Admin)]
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PositionUpdateDto dto)
    {
        var updatedDto = await _service.UpdateRangeAsync(dto);

        return Ok(updatedDto.First());
    }

    [AuthorizeRole(UserRole.Admin)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedDto = await _service.RemoveRange(id);

        return Ok(deletedDto.First());
    }
}