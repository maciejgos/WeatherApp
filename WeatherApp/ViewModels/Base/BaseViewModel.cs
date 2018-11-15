using System;
using System.Net.Http;
using WeatherApp.Services;

namespace WeatherApp.ViewModels.Base
{
    public class BaseViewModel : MvvmHelpers.BaseViewModel
    {
        protected readonly IApiService _service;

        public BaseViewModel()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.WeatherApiEndpoint)
            };
            _service = new ApiService(httpClient);
        }
    }
}
