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
            IWeatherService weatherService = null;
            if (AppSettings.UseMocks)
            {
                weatherService = new MockWeatherService();
            }

            // Act
            OperationResult<WeatherModel> operationResult = await weatherService.GetCurrentWeatherAsync(city: "Pruszków");

            // Assert
            Assert.True(operationResult.Success);
            Assert.NotNull(operationResult.Result);
            Assert.Equal("Pruszków", operationResult.Result.Name);
        }

        [Fact]
        public async Task ThrowsConnectivityExceptionIfNoNetwork()
        {
            // Arrange
            IWeatherService weatherService = null;
            if (AppSettings.UseMocks)
            {
                weatherService = new MockWeatherService();
            }

            // Act
            OperationResult<WeatherModel> operationResult = await weatherService.GetCurrentWeatherAsync(city: "NetworkConnectivity");

            // Assert
            Assert.False(operationResult.Success);
            Assert.NotNull(operationResult.Exception);
            Assert.Equal(typeof(ConnectivityException), operationResult.Exception.GetType());
        }
    }
}
