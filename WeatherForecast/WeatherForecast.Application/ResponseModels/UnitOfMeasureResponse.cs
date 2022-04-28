using System;

namespace WeatherForecast.Application.ResponseModels
{
    public  class UnitOfMeasureResponse
    {
        public Guid Id { get; set; }

        public string Unit { get; set; }

        public int UnitType { get; set; }
    }
}
