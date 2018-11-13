using System.Threading.Tasks;
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
            var service = new ApiService();
            
            // Act
            var response = await service.GetCurrentWeatherAsync(city);

            // Assert
            Assert.IsType<WeatherModel>(response);
            Assert.Equal(city, response.Name);
            Assert.NotNull(response.Main);
        }
    }
}