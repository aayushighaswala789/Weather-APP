using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Interfaces.Repositories;
using WeatherForecast.Infrastructure.Data;
using WeatherForecast.Infrastructure.Repositories;
using WeatherForecast.Infrastructure.Services;

namespace WeatherForecast.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WeatherForecastDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped<IWeatherCastRepository, WeatherCastRepository>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IForecastService, ForecastService>();
            return services;
        }
    }
}
