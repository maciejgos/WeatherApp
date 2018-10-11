using Autofac;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class Locator
    {
        IContainer container;
        ContainerBuilder containerBuilder;

        public static Locator Instance { get; } = new Locator();

        public Locator()
        {
            containerBuilder = new ContainerBuilder();

            if (AppSettings.UseMocks)
            {
                containerBuilder.RegisterType<MockWeatherApiService>().As<IWeatherApiService>();
            }
            else
            {
                containerBuilder.RegisterType<WeatherApiService>().As<IWeatherApiService>();
            }

            containerBuilder.RegisterType<LocalWeatherViewModel>();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public void Build() => container = containerBuilder.Build();
    }
}
