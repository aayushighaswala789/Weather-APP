using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Application.Handlers;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Queries;
using WeatherForecast.Application.ResponseModels;
using WeatherForecast.Application.Test.Mocks;
using Xunit;

namespace WeatherForecast.Application.Test.Queries
{
    public class GetLocationQueryHandlerTest
    {
        private readonly Mock<ILocationService> _mock;
        public GetLocationQueryHandlerTest()
        {
            _mock = MockLocationService.GetLocationService();

        }

        [Fact]
        public async Task GetLocationTest()
        {
            var handler = new GetLocationQueryHandler(_mock.Object);
            var result = await handler.Handle(new GetLocationQuery("Surat"), CancellationToken.None);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetLocation_MatchTest()
        {
            var handler = new GetLocationQueryHandler(_mock.Object);
            var result = await handler.Handle(new GetLocationQuery("Surat"), CancellationToken.None);
            Assert.NotNull(result);

            var data = result as List<LocationResponse>;
            Assert.Equal(202441, data[0].Key);
            Assert.Equal("Surat", data[0].LocalizedName);
        }

        [Fact]
        public async Task GetLocation_NotFoundTest()
        {
            var handler = new GetLocationQueryHandler(_mock.Object);
            var result = await handler.Handle(new GetLocationQuery("Baroda"), CancellationToken.None);
            Assert.Empty(result);
        }
    }
}
