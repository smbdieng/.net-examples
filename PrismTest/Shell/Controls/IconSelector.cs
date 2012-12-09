using System;
using System.Windows.Data;

namespace Shell.Controls
{
    public class IconSelector : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            if ( value == null ) return string.Empty;

            if ( value.GetType().Name.Contains( "EditView" ) )
                return "/Shell;component/Images/ItemIcon.png";

            return "/Shell;component/Images/SyncIcon.png";
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            return string.Empty;
        }
    }
}
