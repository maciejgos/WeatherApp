using System;
using System.Collections.Generic;
using WeatherApp.ViewModels;
using WeatherApp.ViewModels.Base;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class CurrentPage : ContentPage
    {
        public CurrentPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.CurrentViewModel;
        }
    }
}
