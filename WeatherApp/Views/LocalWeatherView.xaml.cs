using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class LocalWeatherView : ContentPage
    {
        public LocalWeatherView()
        {
            InitializeComponent();

            BindingContext = Locator.Instance.Resolve<LocalWeatherViewModel>();
        }
    }
}
