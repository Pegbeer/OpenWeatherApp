using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App.Converter
{
    public class KelvinToCelciusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double grados = double.Parse(value.ToString());
            int entero = System.Convert.ToInt32(Math.Floor(grados));
            var result= (entero-273);

            if (grados != 0)
            {
                return result;
            }
            else
            {
                return "--";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
