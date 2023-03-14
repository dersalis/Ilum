using System;
using FluentValidation;
using Ilum.Api.Features.Commands;

namespace Ilum.Api.Features.Validators;

public class AuthenticationValidator : AbstractValidator<AuthenticationCommand>
{
	public AuthenticationValidator()
	{
		RuleFor(m => m.Email)
			.NotEmpty()
			.EmailAddress();

		RuleFor(m => m.Password)
			.NotEmpty()
			.MinimumLength(6);
	}
}

