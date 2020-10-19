using App.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherViewModel ViewModel { get; set; } = MainViewModel.GetInstance().WeatherViewModel;
        public WeatherPage()
        {
            InitializeComponent();
            SizeChanged += WeatherPage_SizeChanged;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if(e.NetworkAccess != NetworkAccess.Internet)
            {
                var ctx = (WeatherViewModel)this.BindingContext;
                ctx.SetUpValues();
                PopupNavigation.Instance.PushAsync(new WarningView());

            }
            else
            {
                var ctx = (WeatherViewModel)this.BindingContext;
                ctx.SetUpData();
            }
        }

        private void WeatherPage_SizeChanged(object sender, EventArgs e)
        {
            bool isPortrait = this.Height > this.Width;
            stackL.Orientation = (isPortrait ? StackOrientation.Vertical : StackOrientation.Horizontal);
        }

        protected override void OnAppearing()
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                var ctx = (WeatherViewModel)this.BindingContext;
                ctx.SetUpValues();
                PopupNavigation.Instance.PushAsync(new WarningView());
            }
            else
            {
                var ctx = (WeatherViewModel)this.BindingContext;
                ctx.SetUpData();
            }
            base.OnAppearing();
        }
    }
}