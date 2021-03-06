﻿using FCNuvem.FidelizaAluno.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FCNuvem.FidelizaAluno.Core.DependecyInjection
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services) => services
            .AddServices();

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            var servicesType = typeof(Extensions).Assembly.GetTypes()
               .Where(t => typeof(ServiceBase).IsAssignableFrom(t) && t.BaseType != typeof(object) && !t.IsAbstract);

            foreach (var type in servicesType)
            {
                services.AddScoped(type);
            }

            return services;
        }

        //private static IServiceCollection AddCoreResource(this IServiceCollection services)
        //{
        //    var resourceTypes = typeof(Extensions).Assembly.GetTypes()
        //        .Where(t => typeof(ResourceBase).IsAssignableFrom(t));

        //    foreach (var resourceType in resourceTypes)
        //        services.AddSingleton(resourceType, p => AddResourceFactory(resourceType));

        //    return services;
        //}

        //private static object AddResourceFactory(Type resourceType)
        //{
        //    var instance = (ResourceBase)Activator.CreateInstance(resourceType);
        //    instance.Init();
        //    return instance;
        //}
    }
}
