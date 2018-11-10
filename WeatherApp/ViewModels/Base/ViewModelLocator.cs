namespace WeatherApp.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static CurrentViewModel _currentViewModel;

        public static CurrentViewModel CurrentViewModel => AppSettings.IsInDesignMode
            ? new CurrentViewModel {City = "Pruszków", Temperature = 20, Unit = "C"}
            : _currentViewModel = new CurrentViewModel();
    }
}