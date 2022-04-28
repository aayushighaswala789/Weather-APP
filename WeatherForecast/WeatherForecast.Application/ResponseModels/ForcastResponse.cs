using System;

namespace WeatherForecast.Application.ResponseModels
{
    public class ForcastResponse
    {
        public Guid Id { get; set; }

        public string LocationName { get; set; }

        public DateTime ForecastDate { get; set; }

        public TempResponse Temperature { get; set; }

        public TempResponse RealFeelTemperature { get; set; }

        public ForecastDataResponse Day { get; set; }

        public ForecastDataResponse Night { get; set; }
    }
}
