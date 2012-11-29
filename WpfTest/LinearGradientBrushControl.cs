using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest
{
    public class LinearGradientBrushControl : Control
    {
        public LinearGradientBrushControl()
        {
            DataContext = this;
        }

        static LinearGradientBrushControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LinearGradientBrushControl), new FrameworkPropertyMetadata(typeof(LinearGradientBrushControl)));
        }

        public static readonly DependencyProperty StartColorProperty = DependencyProperty.Register("StartColor", typeof(Color), typeof(LinearGradientBrushControl), new UIPropertyMetadata((Color)Colors.Red));

        public Color StartColor
        {
            get
            {
                return (Color)GetValue(StartColorProperty);
            }
            set
            {
                SetValue(StartColorProperty, value);
            }
        }

        public static readonly DependencyProperty StopColorProperty = DependencyProperty.Register("StopColor", typeof(Color), typeof(LinearGradientBrushControl), new UIPropertyMetadata((Color)Colors.Blue));

        public Color StopColor
        {
            get
            {
                return (Color)GetValue(StopColorProperty);
            }
            set
            {
                SetValue(StopColorProperty, value);
            }
        }
    }
}