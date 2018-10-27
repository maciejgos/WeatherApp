using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Exceptions;
using WeatherApp.Models;
using WeatherApp.ViewModels.Base;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class LocalWeatherViewModel : BaseViewModel
    {
        string city;
        string weather;
        int temp;

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string Description
        {
            get => weather;
            set => SetProperty(ref weather, value);
        }

        public int Temp
        {
            get => temp;
            set => SetProperty(ref temp, value);
        }

        public LocalWeatherViewModel()
        {
            Title = "Home";
            Icon = "";

            Task.WhenAll(InitializeAsync());
        }

        public async Task InitializeAsync()
        {
            IsBusy = true;

            var operationResult = await  ApiManager.GetCurrentWeatherAsync(city: "Pruszków");

            if (operationResult.Success)
            {
                BindData(operationResult.Result);

                IsBusy = false;
            }
            else
            {
                if (operationResult.Exception is ConnectivityException)
                {
                    await Application.Current.MainPage.DisplayAlert("Błąd", "Brak połączenia z siecią", "Ok");
                }
                else
                {
                    // TODO: Handle exception in App Center
                    Debug.WriteLine($"Error occur: {operationResult.Exception}");

                    await Application.Current.MainPage.DisplayAlert("Błąd", "Wystąpił błąd. Spróbuj ponownie.", "Ok");
                }
            }
        }

        void BindData(WeatherModel result)
        {
            City = result.Name;
            Description = result.Weather.FirstOrDefault().Description;
            Temp = result.Main.Temp;
        }
    }
}
