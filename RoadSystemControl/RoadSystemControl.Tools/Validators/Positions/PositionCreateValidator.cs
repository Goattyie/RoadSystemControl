using FluentValidation;
using RoadSystemControl.Domains.Dtos.Create;

namespace RoadSystemControl.Tools.Validators.Positions;

public class PositionCreateValidator : AbstractValidator<PositionCreateDto>
{
    public PositionCreateValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(20);
    }
}