using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class MockWeatherApiService : IWeatherApiService
    {
        static WeatherModel weatherModel = new WeatherModel
        {
            Main = new Main
            {
                Temp = 20
            },
            Name = "Pruszków",
            Weather = new List<Weather>
            {
                new Weather
                {
                    Main = "Clear",
                    Description = "clear sky"
                }
            }
        };

        public async Task<WeatherModel> GetCurrentAsync(string city)
        {
            await Task.Delay(1000);

            return weatherModel;
        }
    }
}
