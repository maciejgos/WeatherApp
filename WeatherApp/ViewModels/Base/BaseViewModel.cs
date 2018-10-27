using WeatherApp.Services;

namespace WeatherApp.ViewModels.Base
{
    public class BaseViewModel : MvvmHelpers.BaseViewModel
    {
        IApiManager apiManager;
        public IApiManager ApiManager => apiManager ?? (apiManager = new ApiManager(WeatherHttpClient.Instance));
    }
}
