using System;

namespace WeatherForecast.Application.ResponseModels
{
    public class ForecastDataResponse
    {
        public Guid Id { get; set; }

        public int Icon { get; set; }

        public string IconPhrase { get; set; }

        public decimal CloudCover { get; protected set; }
        public decimal WindSpeed { get; set; }

        public UnitOfMeasureResponse WindSpeedUnitOfMeasure { get; set; }
    }
}
