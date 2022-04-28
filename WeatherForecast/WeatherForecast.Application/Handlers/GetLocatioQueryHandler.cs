using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Queries;
using WeatherForecast.Application.ResponseModels;

namespace WeatherForecast.Application.Handlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, IEnumerable<LocationResponse>>
    {
        private readonly ILocationService _service;

        public GetLocationQueryHandler(ILocationService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<LocationResponse>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.GetLocation(request.City);
            return response.ToList();
        }
    }
}
