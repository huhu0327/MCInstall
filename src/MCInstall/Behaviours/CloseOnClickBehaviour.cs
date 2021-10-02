using System.Windows;
using System.Windows.Controls;

namespace MCInstall.Behaviours
{
    internal class CloseOnClickBehaviour
    {
        public static readonly DependencyProperty IsEnableProperty =
            DependencyProperty.RegisterAttached(
                "IsEnable",
                typeof(bool),
                typeof(CloseOnClickBehaviour),
                new PropertyMetadata(default(bool), OnIsEnablePropertyChanged));


        public static void SetIsEnable(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsEnableProperty, value);
        }

        private static void OnIsEnablePropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not Button button || args.NewValue is not bool newValue)
                return;

            if (newValue)
            {
                button.Click += OnClick;
                return;
            }

            button.Click -= OnClick;
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