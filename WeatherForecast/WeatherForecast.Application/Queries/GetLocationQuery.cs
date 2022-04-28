using MediatR;
using System.Collections.Generic;
using WeatherForecast.Application.ResponseModels;

namespace WeatherForecast.Application.Queries
{
    public record GetLocationQuery(string City) : IRequest<IEnumerable<LocationResponse>>; 
}
