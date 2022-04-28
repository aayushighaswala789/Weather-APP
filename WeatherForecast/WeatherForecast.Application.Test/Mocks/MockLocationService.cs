using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.ResponseModels;

namespace WeatherForecast.Application.Test.Mocks
{
    public class MockLocationService
    {
        public static  Mock<ILocationService> GetLocationService()
        {
            var mock = new Mock<ILocationService>();
            var locationResponse = new List<LocationResponse>()
            {
                new LocationResponse()
                {
                    Key = 202441,
                    LocalizedName = "Surat",
                    Country = new Country()
                    {
                        ID = "IN",
                        LocalizedName = "India"
                    }
                },
                new LocationResponse()
                {
                    Key = 203449,
                    LocalizedName = "Surabaya",
                    Country = new Country()
                    {
                        ID = "IN",
                        LocalizedName = "Indonesia"
                    }
                }
            };

            mock.Setup(x => x.GetLocation(It.IsAny<string>()))
                .ReturnsAsync((string city) => locationResponse.Where(x => x.LocalizedName.ToLower().StartsWith(city.ToLower())));
            return mock;
        }
    }
}
