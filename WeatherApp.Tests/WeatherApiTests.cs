using System;
using System.Threading.Tasks;
using WeatherApp.Exceptions;
using WeatherApp.Models;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.Tests
{
    public class WeatherApiTests
    {
        [Fact]
        public async Task CanGetCurrentWeatherForLocation()
        {
            // Arrange
            IApiManager apiManager = new ApiManager(new MockWeatherService());

            // Act
            OperationResult<WeatherModel> operationResult = await apiManager.GetCurrentWeatherAsync(city: "Pruszków");

            // Assert
            Assert.True(operationResult.Success);
            Assert.NotNull(operationResult.Result);
            Assert.Equal("Pruszków", operationResult.Result.Name);
        }

        [Fact]
        public async Task ThrowsConnectivityExceptionIfNoNetwork()
        {
            // Arrange
            IApiManager apiManager = new ApiManager(new MockWeatherService());

            // Act
            OperationResult<WeatherModel> operationResult = await apiManager.GetCurrentWeatherAsync(city: "NetworkConnectivity");

            // Assert
            Assert.False(operationResult.Success);
            Assert.NotNull(operationResult.Exception);
            Assert.Equal(typeof(ConnectivityException), operationResult.Exception.GetType());
        }
    }
}
