using System;
using Mapster;

namespace MapsterMapper;

public class ServiceMapper : Mapper
{
    internal const string DI_KEY = "Mapster.DependencyInjection.sp";

    private readonly IServiceProvider _serviceProvider;

    public ServiceMapper(IServiceProvider serviceProvider, TypeAdapterConfig config)
        : base(config)
    {
        _serviceProvider = serviceProvider;
    }

    public override ITypeAdapterBuilder<TSource> From<TSource>(TSource source)
    {
        return base.From(source).AddParameters("Mapster.DependencyInjection.sp", _serviceProvider);
    }

    public override TDestination Map<TDestination>(object source)
    {
        using MapContextScope mapContextScope = new MapContextScope();
        mapContextScope.Context.Parameters["Mapster.DependencyInjection.sp"] = _serviceProvider;
        return base.Map<TDestination>(source);
    }

    public override TDestination Map<TSource, TDestination>(TSource source)
    {
        using MapContextScope mapContextScope = new MapContextScope();
        mapContextScope.Context.Parameters["Mapster.DependencyInjection.sp"] = _serviceProvider;
        return base.Map<TSource, TDestination>(source);
    }

    public override TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        using MapContextScope mapContextScope = new MapContextScope();
        mapContextScope.Context.Parameters["Mapster.DependencyInjection.sp"] = _serviceProvider;
        return base.Map(source, destination);
    }

    public override object Map(object source, Type sourceType, Type destinationType)
    {
        using MapContextScope mapContextScope = new MapContextScope();
        mapContextScope.Context.Parameters["Mapster.DependencyInjection.sp"] = _serviceProvider;
        return base.Map(source, sourceType, destinationType);
    }

    public override object Map(object source, object destination, Type sourceType, Type destinationType)
    {
        using MapContextScope mapContextScope = new MapContextScope();
        mapContextScope.Context.Parameters["Mapster.DependencyInjection.sp"] = _serviceProvider;
        return base.Map(source, destination, sourceType, destinationType);
    }
}