using MediatR;
using System.Collections.Generic;
using WeatherForecast.Application.ResponseModels;

namespace WeatherForecast.Application.Queries
{
    public record GetForecastQuery(int LocationKey) : IRequest<IEnumerable<ForcastResponse>>;
}
