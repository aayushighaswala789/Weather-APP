using AutoMapper;
using WeatherForecast.Application.ResponseModels;
using WeatherForecast.Core.Entities;

namespace WeatherForecast.Application.MappingProfiles
{
    public class ForecastMapping : Profile
    {
        public ForecastMapping()
        {
            CreateMap<WeatherCast, ForcastResponse>();
            CreateMap<Temperature, TempResponse>();
            CreateMap<ForecastDetail, ForecastDataResponse>();
            CreateMap<UnitMeasure, UnitOfMeasureResponse>();
        }
    }
}
