namespace WeatherApp
{
    public static class AppSettings
    {
        // Open Weather Endpoints
        const string defaultEndpoint = "https://api.openweathermap.org";
        const string defaultApiKey = "{YOUR_API_KEY}";

        // App Center
        const string defaultAppCenteriOS = "";
        const string defaultAppCenterAndroid = "";

        // Fake
        const bool defaultUseMocks = false;

        // Metric format
        const string defaultWeatherFormat = "metric";

        public static string WeatherEndpoint => defaultEndpoint;
        public static string WeatherApiKey => defaultApiKey;

        public static string AppCenteriOSApiKey => defaultAppCenteriOS;
        public static string AppCenterAndroidApiKey => defaultAppCenterAndroid;

        public static bool UseMocks => defaultUseMocks;

        public static string WeatherFormat => defaultWeatherFormat;
    }
}
