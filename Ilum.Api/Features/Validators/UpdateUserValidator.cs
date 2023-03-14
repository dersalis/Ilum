using System;
using FluentValidation;
using Ilum.Api.Features.Commands;
using MediatR;

namespace Ilum.Api.Features.Validators;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
	public UpdateUserValidator()
	{
        RuleFor(m => m.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.NewPassword)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(m => m.NewPassword)
            .NotEmpty()
            .MinimumLength(6)
            .Equal(m => m.RepeatedPassword);
    }
}