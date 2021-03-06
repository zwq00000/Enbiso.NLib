﻿using System;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Enbiso.NLib.Cqrs
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services, bool autoLoadHandlers = true)
        {
            if(!autoLoadHandlers) return services.AddCqrs();

            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => !a.IsDynamic);
            return services.AddCqrs(assembly);
        }

        public static IServiceCollection AddCqrs(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services.All(s => s.ServiceType != typeof(IMediator)))
                services.AddMediatR(assemblies);
            
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            return services;
        }        
    }
}