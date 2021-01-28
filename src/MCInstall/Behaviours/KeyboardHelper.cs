using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MCInstall.Behaviours
{
    internal class KeyboardHelper
    {
        public static readonly DependencyProperty IsBlockSpacebarProperty =
            DependencyProperty.RegisterAttached("IsBlockSpacebar", typeof(bool), typeof(KeyboardHelper), new PropertyMetadata(default(bool), OnTextboxPropertyChanged));

        public static void SetIsBlockSpacebar(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsBlockSpacebarProperty, value);
        }


        private static void OnTextboxPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not TextBox textbox) return;

            if ((bool)args.NewValue == true)
            {
                textbox.PreviewKeyDown += OnKeyDown;
                return;
            }

            textbox.PreviewKeyDown -= OnKeyDown;
        }

        private static void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = (e.Key == System.Windows.Input.Key.Space);
        }
    }
}
