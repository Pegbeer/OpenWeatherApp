using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModel
{
    public class MainViewModel
    {
        private static MainViewModel instance;

        public WeatherViewModel WeatherViewModel { get; set; }

        public MainViewModel()
        {
            instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();

            }
            return instance;
        }
    }
}
