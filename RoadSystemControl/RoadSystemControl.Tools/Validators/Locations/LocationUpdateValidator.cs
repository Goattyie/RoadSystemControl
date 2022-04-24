using FluentValidation;
using RoadSystemControl.Domains.Dtos.Update;

namespace RoadSystemControl.Tools.Validators.Locations;

public class LocationUpdateValidator : AbstractValidator<LocationUpdateDto>
{
    public LocationUpdateValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(20);
    }
}