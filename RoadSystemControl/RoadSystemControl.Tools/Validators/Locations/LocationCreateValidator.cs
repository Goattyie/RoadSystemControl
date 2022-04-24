using FluentValidation;
using FluentValidation.Results;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Tools.Validators.Locations;

public class LocationCreateValidator : AbstractValidator<LocationCreateDto>
{
    public LocationCreateValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(20);
    }
}