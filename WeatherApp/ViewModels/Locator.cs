﻿using Autofac;

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

            containerBuilder.RegisterType<LocalWeatherViewModel>();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public void Build() => container = containerBuilder.Build();
    }
}