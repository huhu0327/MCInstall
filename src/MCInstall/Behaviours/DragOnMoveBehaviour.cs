using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MCInstall.Behaviours
{
    internal class DragOnMoveBehaviour
    {

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnable", typeof(bool),
                typeof(DragOnMoveBehaviour), new PropertyMetadata(default(bool), OnIsEnabledPropertyChanged));

        public static void SetIsEnable(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsEnabledProperty, value);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not UIElement uiElement || (args.NewValue is bool) == false)
                return;

            if ((bool)args.NewValue == true)
            {
                uiElement.MouseMove += OnMove;
                return;
            }

            uiElement.MouseMove -= OnMove;
        }

        private static void OnMove(object sender, MouseEventArgs args)
        {
            if (sender is not UIElement uiElement || args.LeftButton != MouseButtonState.Pressed) return;

            var window = Window.GetWindow(uiElement);

            window?.DragMove();
        }

    }
}
