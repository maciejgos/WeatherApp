namespace WeatherApp
{
    public class AppSettings
    {
        const bool  _defaultIsInDesignMode = true;

        public static bool IsInDesignMode { get; set; } = _defaultIsInDesignMode;
    }
}