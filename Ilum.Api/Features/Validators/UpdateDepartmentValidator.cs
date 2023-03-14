using System;
using FluentValidation;
using Ilum.Api.Features.Commands;

namespace Ilum.Api.Features.Validators;

public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
{
	public UpdateDepartmentValidator()
	{
        RuleFor(m => m.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}