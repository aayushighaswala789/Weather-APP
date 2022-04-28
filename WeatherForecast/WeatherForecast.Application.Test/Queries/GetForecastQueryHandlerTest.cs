using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Application.Handlers;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.MappingProfiles;
using WeatherForecast.Application.Queries;
using WeatherForecast.Application.ResponseModels;
using WeatherForecast.Application.Test.Mocks;
using Xunit;

namespace WeatherForecast.Application.Test.Queries
{
    public class GetForecastQueryHandlerTest
    {
        private readonly IMapper mapper;

        private readonly Mock<IForecastService> _mock;
        public GetForecastQueryHandlerTest()
        {
            _mock = MockForeCastService.GetService();
            var mapping = new MapperConfiguration(c =>
            {
                c.AddProfile<ForecastMapping>();
            });
            mapper = mapping.CreateMapper();
        }

        [Fact]
        public async Task GetForecastDataTest()
        {
            var handler = new GetForecastQueryHandler(mapper, _mock.Object);
            var result = await handler.Handle(new GetForecastQuery(123), CancellationToken.None);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetForecastData_MatchTest()
        {
            var handler = new GetForecastQueryHandler(mapper, _mock.Object);
            var result = await handler.Handle(new GetForecastQuery(123), CancellationToken.None);
            Assert.NotNull(result);

            var data = result as List<ForcastResponse>;
            Assert.Equal(5, data[0].Day.Icon);
            Assert.Equal("Hazy sunshine", data[0].Day.IconPhrase);
        }

        [Fact]
        public async Task GetForecastData_NotFoundTest()
        {
            var handler = new GetForecastQueryHandler(mapper, _mock.Object);
            var result = await handler.Handle(new GetForecastQuery(124), CancellationToken.None);
            Assert.Empty(result);
        }
    }
}
