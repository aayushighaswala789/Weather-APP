using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Core.Entities;

namespace WeatherForecast.Application.Test.Mocks
{
    public class MockForeCastService
    {
        public static Mock<IForecastService> GetService()
        {
            var mock = new Mock<IForecastService>();

            var weatherCastList = new List<WeatherCast>()
            {
                new WeatherCast(Guid.NewGuid(), 123, DateTime.Now)
                    .SetTemperature(Guid.NewGuid(), 77,103,Guid.NewGuid())
                    .SetRealFeelTemperature(Guid.NewGuid(), 77,77, Guid.NewGuid(),null,null)
                    .SetDay(Guid.NewGuid(), 5, "Hazy sunshine",0, 0,Guid.NewGuid())
                    .SetNight(Guid.NewGuid(), 33, "Hot", 0, 0,Guid.NewGuid()),
                new WeatherCast(Guid.NewGuid(), 123, DateTime.Now.AddDays(1))
                    .SetTemperature(Guid.NewGuid(), 79,100,Guid.NewGuid())
                    .SetRealFeelTemperature(Guid.NewGuid(), 60,60, Guid.NewGuid(),null,null)
                    .SetDay(Guid.NewGuid(), 5, "Hazy sunshine",0, 0,Guid.NewGuid())
                    .SetNight(Guid.NewGuid(), 30, "Clear", 0, 0,Guid.NewGuid())

            };
            mock.Setup(x => x.ListForecast(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int locationKey, CancellationToken token) => weatherCastList.Where(x => x.LocationKey == locationKey).ToList());
            return mock;
        }
    }
}
