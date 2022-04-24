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
public class LocationsController : AbstractController<LocationCreateDto, LocationUpdateDto, LocationGetDto>
{
    public LocationsController(AbstractValidator<LocationCreateDto> createValidator, AbstractValidator<LocationUpdateDto> updateValidator, ILocationService service) 
        : base(service, createValidator, updateValidator) { }
}