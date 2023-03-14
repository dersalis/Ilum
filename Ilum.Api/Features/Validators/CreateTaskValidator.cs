using System;
using MediatR;
using FluentValidation;
using Ilum.Api.Features.Commands;

namespace Ilum.Api.Features.Validators;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
	public CreateTaskValidator()
	{
        RuleFor(m => m.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.Description)
            .MaximumLength(200);

        RuleFor(m => m.Comment)
            .MaximumLength(200);
    }
}