using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Interfaces.Repositories;
using WeatherForecast.Application.ResponseModels;
using WeatherForecast.Core.Entities;

namespace WeatherForecast.Infrastructure.Services
{
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IWeatherCastRepository _repository;

        public ForecastService(HttpClient httpClient, IConfiguration configuration, IWeatherCastRepository repository)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _repository = repository;
        }
        public async Task<IEnumerable<WeatherCast>> ListForecast(int locationKey, CancellationToken cancellationToken = default)
        {
            var currentDate = DateTime.Now.Date;

            var forecast = await _repository.GetForecast(locationKey, currentDate, cancellationToken: cancellationToken);
            if (forecast == null || forecast.Count < 1)
            {
                var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecastResponse>($"{_configuration["WeatherSettings:BaseUrl"]}/forecasts/v1/daily/5day/{locationKey}?apikey={_configuration["WeatherSettings:ApiKey"]}&details=true&metric=true", cancellationToken);

                if (forecasts != null)
                {
                    var convertedForecasts = await Bind(forecasts, locationKey);
                    var result = await _repository.AddForecastRange(convertedForecasts, cancellationToken);
                }
            }

            var response = await _repository.GetForecast(locationKey, currentDate, 7, true, cancellationToken);
            return response;
        }

        public async Task<List<WeatherCast>> Bind(WeatherForecastResponse model, int locationKey)
        {
            var unitOfMeasures = await _repository.GetUnitOfMeasure();

            List<WeatherCast> forecasts = new List<WeatherCast>();
            foreach (var dailyForecast in model.DailyForecasts)
            {
                var temperatureUnit = unitOfMeasures.FirstOrDefault(x => x.UnitType == dailyForecast.Temperature.Minimum.UnitType);

                var realFeelTemperatureUnit = unitOfMeasures.FirstOrDefault(x => x.UnitType == dailyForecast.RealFeelTemperature.Minimum.UnitType);

                var windSpeedUnit = unitOfMeasures.FirstOrDefault(x => x.UnitType == dailyForecast.Day.Wind.Speed.UnitType);

                var forecast = new WeatherCast(Guid.NewGuid(), locationKey, dailyForecast.Date.Date);
                if (temperatureUnit != null)
                    forecast.SetTemperature(Guid.NewGuid(), dailyForecast.Temperature.Minimum.Value,
                        dailyForecast.Temperature.Maximum.Value, temperatureUnit.Id);

                if (realFeelTemperatureUnit != null)
                    forecast.SetRealFeelTemperature(Guid.NewGuid(), dailyForecast.RealFeelTemperature.Minimum.Value,
                        dailyForecast.Temperature.Maximum.Value, realFeelTemperatureUnit.Id,
                        dailyForecast.RealFeelTemperature.Minimum.Phrase,
                        dailyForecast.RealFeelTemperature.Maximum.Phrase);

                if (windSpeedUnit != null)
                {
                    forecast.SetDay(Guid.NewGuid(), dailyForecast.Day.Icon, dailyForecast.Day.IconPhrase,
                        dailyForecast.Day.Wind.Speed.Value, dailyForecast.Day.CloudCover,
                        windSpeedUnit.Id);

                    forecast.SetNight(Guid.NewGuid(), dailyForecast.Night.Icon, dailyForecast.Night.IconPhrase,
                        dailyForecast.Night.Wind.Speed.Value, dailyForecast.Night.CloudCover,
                        windSpeedUnit.Id);
                }

                forecasts.Add(forecast);
            }

            return forecasts;
        }
    }
}
