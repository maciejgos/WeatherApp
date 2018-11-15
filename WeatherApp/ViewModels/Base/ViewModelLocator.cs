using WeatherApp.Helpers;

namespace WeatherApp.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static CurrentViewModel _currentViewModel;

        public static CurrentViewModel CurrentViewModel => AppSettings.IsInDesignMode
            ? new CurrentViewModel {City = "Pruszków", Temperature = 20.5, Unit = "C", WeeklyForecast = DesignTimeData.WeeklyForecase}
            : _currentViewModel = new CurrentViewModel();
    }
}