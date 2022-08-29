using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MCInstall.Behaviors
{
    public static class CloseOnClickBehavior
    {
        public static readonly DependencyProperty IsEnableProperty =
            DependencyProperty.RegisterAttached("IsEnable", typeof(bool), typeof(CloseOnClickBehavior),
                new PropertyMetadata(default(bool), OnIsEnablePropertyChanged));

        public static void SetIsEnable(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsEnableProperty, value);
        }

        private static void OnIsEnablePropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not Button button)
                return;

            if ((bool)args.NewValue)
            {
                button.Click += OnClick;
            }
        }

        private static void OnClick(object sender, RoutedEventArgs args)
        {
            if (sender is not Button button)
                return;

            button.Click -= OnClick;

            Application.Current.Shutdown();
        }
    }
}