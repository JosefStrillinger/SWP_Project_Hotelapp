using Hotel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp.Models.Converters {
    public class PaymentMethodConverter : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                // object -> PaymentMethod -> int
                return (int)(PaymentMethod)value;
            }
            return (int)PaymentMethod.cash;
        }

        // umgekehrte Richtung
        // int -> PaymentMethod
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                return (PaymentMethod)(int)value;
            }
            return (PaymentMethod)(int)PaymentMethod.cash;
        }
    }
}
