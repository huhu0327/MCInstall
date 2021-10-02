using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MCInstall.Behaviours
{
    internal class KeyboardHelper
    {
        public static readonly DependencyProperty IsBlockSpacebarProperty =
            DependencyProperty.RegisterAttached("IsBlockSpacebar", typeof(bool), typeof(KeyboardHelper),
                new PropertyMetadata(default(bool), OnTextboxPropertyChanged));

        public static void SetIsBlockSpacebar(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsBlockSpacebarProperty, value);
        }


        private static void OnTextboxPropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not TextBox textbox) return;

            if ((bool) args.NewValue)
            {
                textbox.PreviewKeyDown += OnKeyDown;
                return;
            }

            textbox.PreviewKeyDown -= OnKeyDown;
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key is Key.Space;
        }
    }
}