using Microsoft.AspNetCore.Mvc;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Update;

namespace RoadSystemControl.Admin.Api.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PositionCreateDto dto)
    {
        var createdDto = await _service.AddRangeAsync(dto);

        return Ok(createdDto.First());
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PositionUpdateDto dto)
    {
        var updatedDto = await _service.UpdateRangeAsync(dto);

        return Ok(updatedDto.First());
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedDto = await _service.RemoveRange(id);

        return Ok(deletedDto.First());
    }
}