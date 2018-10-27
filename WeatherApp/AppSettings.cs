namespace WeatherApp
{
    public static class AppSettings
    {
        // Open Weather Endpoints
        const string defaultEndpoint = "https://api.openweathermap.org/data/2.5";
        const string defaultApiKey = "{YOUR_API_KEY}";

        // App Center
        const string defaultAppCenteriOS = "";
        const string defaultAppCenterAndroid = "";

        // Fake
        const bool defaultUseMocks = true;

        // Metric format
        const string defaultWeatherUnits = "metric";

        public static string WeatherEndpoint => defaultEndpoint;
        public static string WeatherApiKey => defaultApiKey;

        public static string AppCenteriOSApiKey => defaultAppCenteriOS;
        public static string AppCenterAndroidApiKey => defaultAppCenterAndroid;

        public static bool UseMocks => defaultUseMocks;

        public static string WeatherUnits => defaultWeatherUnits;
    }
}
