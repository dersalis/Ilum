using System;
using FluentValidation;
using Ilum.Api.Features.Commands;

namespace Ilum.Api.Features.Validators;

public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
{
	public CreateDepartmentValidator()
	{
		RuleFor(m => m.Name)
			.NotEmpty()
			.MaximumLength(50);
	}
}

