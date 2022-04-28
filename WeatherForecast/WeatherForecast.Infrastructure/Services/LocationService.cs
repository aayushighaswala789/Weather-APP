using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.ResponseModels;

namespace WeatherForecast.Infrastructure.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public LocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<LocationResponse>> GetLocation(string city)
        {
            var response = await _httpClient.GetFromJsonAsync<List<LocationResponse>>($"{_configuration["WeatherSettings:BaseUrl"]}/locations/v1/cities/autocomplete?apikey={_configuration["WeatherSettings:ApiKey"]}&q={city}");
            return response;
        }
    }
}
