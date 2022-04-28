using AutoMapper;
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
    public class GetForecastQueryHandler : IRequestHandler<GetForecastQuery, IEnumerable<ForcastResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IForecastService _service;

        public GetForecastQueryHandler(IMapper mapper, IForecastService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IEnumerable<ForcastResponse>> Handle(GetForecastQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.ListForecast(request.LocationKey);
           return _mapper.Map<List<ForcastResponse>>(response.ToList());
        }
    }
}
