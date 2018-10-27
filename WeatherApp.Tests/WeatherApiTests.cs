using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
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
            HttpClient httpClient = null;
            FileStream fileStream = null;
            if (AppSettings.UseMocks)
            {
                MockHttpMessageHandler mockHttpMessage = new MockHttpMessageHandler();

                fileStream = new FileStream("test.json", FileMode.Open);
                mockHttpMessage
                    .When("https://api.openweathermap.org/data/2.5/weather?q=Pruszków&appid=000000&units=metric")
                    .Respond("application/json", fileStream);

                httpClient = new HttpClient(mockHttpMessage)
                {
                    BaseAddress = new Uri(AppSettings.WeatherEndpoint)
                };
            }
            else
            {
                httpClient = new HttpClient
                {
                    BaseAddress = new Uri(AppSettings.WeatherEndpoint)
                };
            }

            IApiManager apiManager = new ApiManager(httpClient);

            // Act
            OperationResult<WeatherModel> operationResult = await apiManager.GetCurrentWeatherAsync(city: "Pruszków");

            // Assert
            Assert.True(operationResult.Success);
            Assert.NotNull(operationResult.Result);
            Assert.Equal("Pruszków", operationResult.Result.Name);

            // Cleanup
            fileStream?.Dispose();
        }

        [Fact]
        public async Task ThrowsConnectivityExceptionIfNoNetwork()
        {
            // Arrange
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.WeatherEndpoint)
            };

            IApiManager apiManager = new ApiManager(httpClient);

            // Act
            OperationResult<WeatherModel> operationResult = await apiManager.GetCurrentWeatherAsync(city: "NetworkConnectivity");

            // Assert
            Assert.False(operationResult.Success);
            Assert.NotNull(operationResult.Exception);
            Assert.Equal(typeof(ConnectivityException), operationResult.Exception.GetType());
        }
    }
}
