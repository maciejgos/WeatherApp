using System.Net.Http;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using WeatherApp.Application.Dtos;
using WeatherApp.Application.Extensions;
using WeatherApp.Application.Networking;
using WeatherApp.Features.Local.Models;

namespace WeatherApp.Features.Local.ViewModels
{
    public class LocalWeatherPageViewModel : BindableBase
    {
        string _city = "Warszawa";
        string _temp = "7";
        readonly IApiService _apiService;

        public string City { get => _city; set => SetProperty(ref _city, value); }
        public string Temp { get => _temp; set => SetProperty(ref _temp, value); }

        public DelegateCommand GetCurrentWeatherCommand { get; set; }

        public LocalWeatherPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            GetCurrentWeatherCommand = new DelegateCommand(async () => await OnGetCurrentWeatherCommand());
        }

        async Task OnGetCurrentWeatherCommand()
        {
            if (Valid())
            {
                var response = await _apiService.GetCurrentWeatherAsync(_city) as HttpResponseMessage;
                var model = response.MapToDto<WeatherDto>().MapToModel<CurrentWeatherModel>();

                Temp = $"Current temp in {City} is {model.Temperature}";
            }
        }

        bool Valid()
        {
            return true;
        }
    }
}
