using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using WeatherApp.ViewModels.Base;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class CurrentPage : ContentPage
    {
        private readonly CurrentViewModel _viewModel;
        public CurrentPage()
        {
            InitializeComponent();
            BindingContext = _viewModel ?? (_viewModel = new CurrentViewModel());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.InitializeAsync();
        }
    }
}
