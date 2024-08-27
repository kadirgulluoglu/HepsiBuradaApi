using System;
using System.Reflection;
using HepsiBuradaApi.Application.Exceptions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using MediatR;
using HepsiBuradaApi.Application.Behaviour;

namespace HepsiBuradaApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }
    }
}

