using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Core.Entities;

namespace WeatherForecast.Application.Interfaces
{
    public interface IForecastService
    {
        public Task<IEnumerable<WeatherCast>> ListForecast(int locationKey, CancellationToken cancellationToken = default);
    }
}
