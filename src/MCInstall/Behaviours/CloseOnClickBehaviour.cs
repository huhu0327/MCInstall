using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MCInstall.Behaviours
{
    internal class CloseOnClickBehaviour
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsEnable",
                typeof(bool),
                typeof(CloseOnClickBehaviour),
                new PropertyMetadata(default(bool), OnIsEnabledPropertyChanged));


        public static void SetIsEnabled(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsEnabledProperty, value);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not Button button || (args.NewValue is bool) ==  false)
                return;

            if ((bool)args.NewValue == true)
            {
                button.Click += OnClick;
                return;
            }

            button.PreviewMouseLeftButtonDown -= OnClick;
        }

        private static void OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;

            var window = Window.GetWindow(button);

            window?.Close();
        }

    }
}
