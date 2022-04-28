﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WeatherForecast.Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
