using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel;

namespace Hotelapp.Models.Converters {
    public class GenderConverter : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                // object -> Gender -> int
                return (int)(Gender)value;
            }
            return (int)Gender.notSpecified;
        }

        // umgekehrte Richtung
        // int -> Gender
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                return (Gender)(int)value;
            }
            return (Gender)(int)Gender.notSpecified;
        }
    }
}
