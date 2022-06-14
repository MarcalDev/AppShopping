using AppShopping.LIbraries.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppShopping.LIbraries.Converters
{
    public class EstablishmentTypeConversor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EstablishmentType type = (EstablishmentType)value;

            return (type == EstablishmentType.Store) ? "Loja" : "Restaurante";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
