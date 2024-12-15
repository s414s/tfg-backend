﻿using Application.Behaviours;
using Application.Contracts;
using Application.Implementations;
using Application.Services;
using Domain.Contracts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(AssemblyReference.Assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);

        services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<IUserInfo, UserInfoService>();

        return services;
    }
}
