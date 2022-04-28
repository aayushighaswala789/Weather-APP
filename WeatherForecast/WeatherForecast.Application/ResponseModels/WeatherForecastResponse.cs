using System;
using System.Collections.Generic;

namespace WeatherForecast.Application.ResponseModels
{
    public class WeatherForecastResponse
    {
        public List<DailyForecastResponse> DailyForecasts { get; set; }
    }
    public class DailyForecastResponse
    {
        public DateTime Date { get; set; }

        public TemperatureResponse Temperature { get; set; }

        public TemperatureResponse RealFeelTemperature { get; set; }

        public ForecastDetailResponse Day { get; set; }

        public ForecastDetailResponse Night { get; set; }
    }

    public class TemperatureResponse
    {
        public UnitMeasureResponse Maximum { get; set; }

        public UnitMeasureResponse Minimum { get; set; }
    }

    public class UnitMeasureResponse
    {
        public decimal Value { get; set; }

        public string Unit { get; set; }

        public int UnitType { get; set; }

        public string Phrase { get; set; }
    }

    public class ForecastDetailResponse
    {
        public int Icon { get; set; }

        public string IconPhrase { get; set; }

        public decimal CloudCover { get; set; }

        public WindResponse Wind { get; set; }
    }

    public class WindResponse
    {
        public UnitMeasureResponse Speed { get; set; }
    }
}
