using System;
using System.Reflection;
using HepsiBuradaApi.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiBuradaApi.Application
{
	public static class Registration
	{
		public static void AddApplication(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.AddTransient<ExceptionMiddleware>();
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
		}
	}
}

