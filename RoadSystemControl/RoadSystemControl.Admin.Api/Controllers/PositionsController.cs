using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;

namespace RoadSystemControl.Admin.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PositionsController : AbstractController<PositionCreateDto, PositionUpdateDto, PositionGetDto>
{
    public PositionsController(AbstractValidator<PositionCreateDto> createValidator, AbstractValidator<PositionUpdateDto> updateValidator, IPositionService service) 
        : base(service, createValidator, updateValidator) { }
}