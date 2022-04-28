using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Core.Entities;

namespace WeatherForecast.Application.Interfaces.Repositories
{
    public interface IWeatherCastRepository
    {
        Task<List<WeatherCast>> GetForecast(int locationKey, DateTime date, int days = 1, bool includeChildren = false, CancellationToken cancellationToken = default);

        Task<bool> AddForecastRange(List<WeatherCast> forecasts, CancellationToken cancellationToken = default);

        Task<List<UnitMeasure>> GetUnitOfMeasure(CancellationToken cancellationToken = default);
    }
}
