using MahApps.Metro.IconPacks;
using System.Windows;
using System.Windows.Controls;

namespace MCInstall.Controls
{
    public class IconTabItem : TabItem
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                "Icon", typeof(PackIconFontAwesomeKind), typeof(IconTabItem));

        static IconTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconTabItem), new FrameworkPropertyMetadata(typeof(IconTabItem)));
        }

        public PackIconFontAwesomeKind Icon
        {
            get => (PackIconFontAwesomeKind)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}
