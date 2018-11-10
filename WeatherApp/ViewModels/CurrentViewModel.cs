using System.Collections;
using System.Collections.Generic;

namespace WeatherApp.ViewModels
{
    public class CurrentViewModel
    {
        public int Temperature { get; set; }
        public string City { get; set; }
        public string Unit { get; set; }
        public IEnumerable<ForecastLineViewModel> WeeklyForecast { get; set; }
    }

    public class ForecastLineViewModel
    {
        public string Day { get; set; }
        public int Temperature { get; set; }
    }
}