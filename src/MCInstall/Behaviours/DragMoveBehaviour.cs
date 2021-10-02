using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MCInstall.Behaviours
{
    internal class DragMoveBehaviour
    {
        public static readonly DependencyProperty IsEnableProperty =
            DependencyProperty.RegisterAttached("IsEnable", typeof(bool), typeof(DragMoveBehaviour), new PropertyMetadata(default(bool), OnIsEnabledPropertyChanged));

        public static void SetIsEnable(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsEnableProperty, value);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not UIElement uiElement || args.NewValue is not bool newValue)
            {
                return;
            }

            if (newValue)
            {
                uiElement.MouseMove += OnMove;
                return;
            }

            uiElement.MouseMove -= OnMove;
        }

        private static void OnMove(object sender, MouseEventArgs args)
        {
            if (sender is not UIElement uiElement || args.LeftButton is not MouseButtonState.Pressed)
            {
                return;
            }

            var window = Window.GetWindow(uiElement);
            window?.DragMove();
        }
    }
}