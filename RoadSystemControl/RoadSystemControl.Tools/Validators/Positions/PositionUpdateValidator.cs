using FluentValidation;
using RoadSystemControl.Domains.Dtos.Update;

namespace RoadSystemControl.Tools.Validators.Positions;

public class PositionUpdateValidator : AbstractValidator<PositionUpdateDto>
{
    public PositionUpdateValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(20);
    }
}