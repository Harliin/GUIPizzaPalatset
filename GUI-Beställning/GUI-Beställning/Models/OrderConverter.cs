using GUI_Beställning.Models.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace GUI_Beställning.Models
{
    public class OrderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new FoodModel() { ID = values[0] as string, FoodType = values[1] as string};
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static OrderConverter Instance { get; set; } = new OrderConverter();

    }
}
