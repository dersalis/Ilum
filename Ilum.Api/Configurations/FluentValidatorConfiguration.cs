using System;
using System.Reflection;
using FluentValidation.AspNetCore;
using Ilum.Api.Features.Validators;

namespace Ilum.Api.Configurations;

public static class FluentValidatorConfiguration
{
	public static void AddFluentValidatorService(this IServiceCollection services)
	{
        //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>());
        services.AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly());
            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            fv.ImplicitlyValidateChildProperties = true;
        });
    }
}

