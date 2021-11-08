using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace gratch_desktop.Helpers
{
    public class TabItemHelper : DependencyObject
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached(
            "Icon", typeof(DrawingImage), typeof(TabItemHelper));


        public static void SetIcon(DependencyObject target, DrawingImage value)
        {
            target.SetValue(IconProperty, value);
        }

        public static DrawingImage GetIcon(DependencyObject target)
        {
            return (DrawingImage)target.GetValue(IconProperty);
        }
    }
}
