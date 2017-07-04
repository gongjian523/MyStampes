using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;


namespace MyStampes.Converter
{
    class SelectedItemIndexBkColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if((int)value % 2 == 0)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            else
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFECF0F1"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
