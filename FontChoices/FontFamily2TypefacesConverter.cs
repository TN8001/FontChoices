using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace FontChoices
{
    /// <summary>Convert FontFamily to FontFamily.Typefaces</summary>
    internal class FontFamily2TypefacesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var typefaces = (value as FontFamily)?.GetTypefaces();

            if(typefaces != null)
            {
                var typefaceJps = new List<TypefaceJP>();
                foreach(var typeface in typefaces)
                    typefaceJps.Add(new TypefaceJP(typeface));

                return typefaceJps.Distinct(); //メイリオがいつの間にか重複するようになっていた？？
            }

            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
