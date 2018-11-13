using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using WeatherApp.Models;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.ApiTests
{
    public class ApiServiceTests
    {
        [Theory]
        [InlineData("Pruszków")]
        public async Task Can_Fetch_Weather_For_Current_Location(string city)
        {
            // Arrange
            ApiService service = null;
            if (AppSettings.UseMocks)
            {
                var mockHttp = new MockHttpMessageHandler();
                var fileStream  = new FileStream("testData.json", FileMode.Open);
                mockHttp
                    .When(HttpMethod.Get,
                        $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=0d039917e0d2820c0dc9ab4f95cf10d8&units=metric")
                    .Respond(HttpStatusCode.OK, "application/json", fileStream);
                
                var httpClient = new HttpClient(mockHttp)
                {
                    BaseAddress = new Uri(AppSettings.WeatherApiEndpoint)
                };
                service = new ApiService(httpClient);
            }
            else
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(AppSettings.WeatherApiEndpoint)
                };
                service = new ApiService(httpClient);
            }
            
            
            // Act
            var response = await service.GetCurrentWeatherAsync(city);

            // Assert
            Assert.IsType<WeatherModel>(response);
            Assert.Equal(city, response.Name);
            Assert.NotNull(response.Main);
        }
    }
}