using System;
using FluentValidation;
using Ilum.Api.Features.Commands;

namespace Ilum.Api.Features.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(m => m.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(50);

        RuleFor(m => m.Login)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.NewPassword)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.RepeatedPassword)
            .NotEmpty()
            .MaximumLength(50);
    }
}

