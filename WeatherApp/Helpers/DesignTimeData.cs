using System.Collections.Generic;
using WeatherApp.ViewModels;

namespace WeatherApp.Helpers
{
    internal static class DesignTimeData
    {
        public static IEnumerable<ForecastLineViewModel> WeeklyForecase { get; }

        static DesignTimeData()
        {
            WeeklyForecase = new List<ForecastLineViewModel>
            {
                new ForecastLineViewModel
                {
                    Day = "Niedziela",
                    Temperature = 10
                },
                new ForecastLineViewModel
                {
                    Day = "Poniedziałek",
                    Temperature = 8
                }
            };
        }
    }
}