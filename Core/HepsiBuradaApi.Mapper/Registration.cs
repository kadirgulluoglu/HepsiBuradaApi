using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;

namespace HepsiBuradaApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}

