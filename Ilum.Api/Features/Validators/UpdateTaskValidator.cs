using System;
using FluentValidation;
using Ilum.Api.Features.Commands;

namespace Ilum.Api.Features.Validators;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
{
	public UpdateTaskValidator()
	{
        RuleFor(m => m.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.Description)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(m => m.Progress)
            .NotNull()
            .InclusiveBetween(0, 100);

        RuleFor(m => m.Comment)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(m => m.Status)
            .IsInEnum();

        RuleFor(m => m.Priority)
            .IsInEnum();
    }
}