using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfTest
{
    public class Attach
    {
        public static DependencyProperty HoverBrushProperty =
            DependencyProperty.RegisterAttached("HoverBrush",
                                                typeof(Brush),
                                                typeof(Attach),
                                                new PropertyMetadata(null));
        public static void SetHoverBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverBrushProperty, value);
        }
        public static Brush GetHoverBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverBrushProperty);
        }
    }
}
