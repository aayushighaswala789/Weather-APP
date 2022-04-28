using System;

namespace WeatherForecast.Application.ResponseModels
{
    public class TempResponse
    {
        public Guid Id { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public string PhraseForMin { get; set; }

        public string PhraseForMax { get; set; }

        public UnitOfMeasureResponse UnitOfMeasure { get; set; }
    }
}
