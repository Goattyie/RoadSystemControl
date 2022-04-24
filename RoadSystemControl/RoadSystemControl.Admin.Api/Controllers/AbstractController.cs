using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RoadSystemControl.Admin.Api.Core;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Enums;

namespace RoadSystemControl.Admin.Api.Controllers;

public abstract class AbstractController<TCreateDto, TUpdateDto, TGetDto>  : ControllerBase
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
{
    private readonly IService<TCreateDto, TUpdateDto, TGetDto> _service;
    private readonly AbstractValidator<TCreateDto> _createValidator;
    private readonly AbstractValidator<TUpdateDto> _updateValidator;

    public AbstractController(IService<TCreateDto, TUpdateDto, TGetDto> service, 
        AbstractValidator<TCreateDto> createValidator, 
        AbstractValidator<TUpdateDto> updateValidator)
    {
        _service = service;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }
    
    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        var locationDtoList = await _service.GetAsync();

        return Ok(locationDtoList);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(int id)
    {
        var dto = await _service.GetByIdAsync(id);

        return Ok(dto);
    }
    
    [HttpPost]
    [AuthorizeRole(UserRole.Admin, UserRole.Operator)]
    public virtual async Task<IActionResult> Post([FromBody] TCreateDto dto)
    {
        var validation = await _createValidator.ValidateAsync(dto);

        if (!validation.IsValid)
        {
            return Ok(validation.Errors);
        }        
        
        var createdDto = await _service.AddRangeAsync(dto);

        return Ok(createdDto.First());
    }

    [HttpPut]
    [AuthorizeRole(UserRole.Admin, UserRole.Operator)]
    public virtual async Task<IActionResult> Put([FromBody] TUpdateDto dto)
    {
        var validation = await _updateValidator.ValidateAsync(dto);

        if (!validation.IsValid)
        {
            return Ok(validation.Errors);
        }   

        var updatedDto = await _service.UpdateRangeAsync(dto);

        return Ok(updatedDto.First());
    }

    [HttpDelete]
    [AuthorizeRole(UserRole.Admin)]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var deletedDto = await _service.RemoveRange(id);

        return Ok(deletedDto.First());
    }
}
