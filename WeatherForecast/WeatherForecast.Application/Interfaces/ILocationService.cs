using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Application.ResponseModels;

namespace WeatherForecast.Application.Interfaces
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationResponse>> GetLocation(string city);
    }
}
