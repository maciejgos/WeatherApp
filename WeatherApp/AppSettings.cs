namespace WeatherApp
{
    public class AppSettings
    {
        private static bool _defaultUseMocks = true;
        private const bool  _defaultIsInDesignMode = true;
        private const string _apiKey = "{YOUR_API_KEY}";
        private const string _weatherApiEndpoint = "https://api.openweathermap.org/data/2.5";

        public static bool IsInDesignMode { get; set; } = _defaultIsInDesignMode;

        public static string ApiKey => _apiKey;
        public static string WeatherApiEndpoint => _weatherApiEndpoint;
        public static bool UseMocks => _defaultUseMocks;
    }
}