using GUI_Beställning.Models.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace GUI_Beställning
{
    public class OrderConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //int id = 0;
            //if (values[0] is int)
            //{
            //    id = (int)values[0];
            //}

            //return new FoodModel() { ID = id, FoodType = values[1] as string};

            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public static OrderConverter Instance { get; set; } = new OrderConverter();

    }
}
