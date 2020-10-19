using App.domain;
using App.Model;
using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class WeatherViewModel : BaseViewModel
    {
        #region attribute
        private RootObject _objeto;
        private ImageSource _source;
        private Weather _clima;
        private bool _isBusy;
        private string _name;
        private bool _isEmpty;
        private Main _mainData;
        #endregion

        #region properties
        public bool IsEmpty
        {
            get { return this._isEmpty; }
            set { SetValue(ref this._isEmpty, value); }
        }

        public Main MainData
        {
            get { return this._mainData; }
            set { SetValue(ref this._mainData, value); }
        }

        [DefaultValue(true)]
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { SetValue(ref this._isBusy, value); }
        }

        public string Name
        {
            get { return this._name; }
            set { SetValue(ref this._name, value); }
        }

        public RootObject Objeto
        {
            get { return this._objeto; }
            set { SetValue(ref this._objeto, value); }
        }

        public ImageSource Source
        {
            get { return this._source; }
            set { SetValue(ref this._source, value); }
        }

        public Weather Clima
        {
            get { return this._clima; }
            set { SetValue(ref this._clima, value); }
        }
        #endregion

        public async void SetUpData()
        {
            IsBusy = true;
            IsEmpty = false;

            var data = new DataSource();
            var location = await Geolocation.GetLastKnownLocationAsync();
            var latitude = location.Latitude;
            var longitud = location.Longitude;
            Objeto = await data.GetWeatherAsync(latitude, longitud);
            var datoclima = Objeto.Clima;
            MainData = Objeto.Principal;
            Name = Objeto.Name;
            var datotemp = Objeto.Principal;
            foreach (var item in datoclima)
            {
                Clima = new Weather { Id = item.Id, Principal = item.Principal, Description = item.Description };
            }

            if (Clima.Principal == "Rain")
            {
                Source = "rainwindow.gif";
            }
            else if (Clima.Principal.Equals("Clouds"))
            {
                Source = "clouds.gif";
            }
            Barrel.Current.Add(key: $"{App.API_KEY}", Name, TimeSpan.FromDays(2));
            Barrel.Current.Add(key: $"{App.API_KEY}", MainData, TimeSpan.FromDays(2));
            Barrel.Current.Add(key: $"{App.API_KEY}", Clima, TimeSpan.FromDays(2));
            IsEmpty = true;
            IsBusy = false;
        }

        public void SetUpValues()
        {
            IsBusy = true;
            IsEmpty = false;
            MainData = Barrel.Current.Get<Main>($"{App.API_KEY}");
            Name = Barrel.Current.Get<string>($"{App.API_KEY}");
            Clima = Barrel.Current.Get<Weather>($"{App.API_KEY}");
            if (Clima.Principal == "Rain")
            {
                Source = "rainwindow.gif";
            }
            else if (Clima.Principal.Equals("Clouds"))
            {
                Source = "clouds.gif";
            }
            IsBusy = false;
            IsEmpty = true;
        }

      
        public Command LocationCommand { get; set; }
    }
}
