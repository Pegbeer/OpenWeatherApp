using App.View;
using MonkeyCache.FileStore;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    public partial class App : Application
    {
        public const string API_KEY = "7a86dc44d5e1973c29925dc009b15f8f";
       
        public App()
        {
            Barrel.ApplicationId = "WeatherApp";
            InitializeComponent();
            MainPage = new WeatherPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
