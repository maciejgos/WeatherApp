using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace WeatherApp.Features.Local.ViewModels
{
    public class LocalWeatherPageViewModel : BindableBase
    {
        string _city = "Warszawa";
        string _temp = "7";

        public string City { get => _city; set => SetProperty(ref _city, value); }
        public string Temp { get => _temp; set => SetProperty(ref _temp, value); }

        public DelegateCommand GetCurrentWeatherCommand { get; set; }

        public LocalWeatherPageViewModel()
        {
            GetCurrentWeatherCommand = new DelegateCommand(async () => await OnGetCurrentWeatherCommand());
        }

        async Task OnGetCurrentWeatherCommand()
        {
            throw new NotImplementedException();
        }
    }
}
