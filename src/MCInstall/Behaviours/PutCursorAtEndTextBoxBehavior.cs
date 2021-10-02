using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MCInstall.Behaviours
{
    internal class PutCursorAtEndTextBoxBehavior
    {
        public static readonly DependencyProperty IsEnableProperty =
            DependencyProperty.RegisterAttached("IsEnable", typeof(bool), typeof(PutCursorAtEndTextBoxBehavior), new PropertyMetadata(default(bool), OnIsEnabledPropertyChanged));

        public static void SetIsEnable(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsEnableProperty, value);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not TextBox textbox)
            {
                return;
            }

            if ((bool)args.NewValue)
            {
                textbox.TextChanged += OnScrollToCaret;
                return;
            }

            textbox.TextChanged -= OnScrollToCaret;
        }

        private static void OnScrollToCaret(object sender, RoutedEventArgs e)
        {
            var textbox = (sender as TextBox);

            //if(textbox.CaretIndex < textbox.Text.Length)
            //{
            //    return;
            //}

            ScrollToEnd(textbox);
        }

        private static void ScrollToEnd(TextBox textBox)
        {
            textBox.Focus();
            textBox.CaretIndex = textBox.Text.Length;
        }
    }
}
