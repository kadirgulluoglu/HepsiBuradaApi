using System;
namespace HepsiBuradaApi.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);

        IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null);

        TDestination Map<TDestination, TSource>(object source, string? ignore = null);

        IList<TDestination> Map<TDestination, TSource>(IList<object> source, string? ignore = null);

    }
}

