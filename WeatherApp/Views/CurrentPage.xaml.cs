using System;
using System.Collections.Generic;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class CurrentPage : ContentPage
    {
        public CurrentPage()
        {
            InitializeComponent();
            BindingContext = new CurrentViewModel();
        }
    }
}
