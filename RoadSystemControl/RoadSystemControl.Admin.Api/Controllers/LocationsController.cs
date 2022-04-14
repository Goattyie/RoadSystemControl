using Microsoft.AspNetCore.Mvc;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Update;

namespace RoadSystemControl.Admin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _service;

    public LocationsController(ILocationService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var locationDtoList = await _service.GetAsync();

        return Ok(locationDtoList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dto = await _service.GetByIdAsync(id);

        return Ok(dto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LocationCreateDto dto)
    {
        var createdDto = await _service.AddRangeAsync(dto);

        return Ok(createdDto.First());
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] LocationUpdateDto dto)
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