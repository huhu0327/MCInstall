using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Microsoft.VisualBasic.Devices;
using Keyboard = System.Windows.Input.Keyboard;

namespace MCInstall.Behaviors
{
    public static class FocusBehavior
    {
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached("IsFocused", typeof(bool?),
                typeof(FocusBehavior), new FrameworkPropertyMetadata(null, IsFocusedChanged));

        public static bool? GetIsFocused(DependencyObject dependencyObject)
        {
            _ = dependencyObject ?? throw new ArgumentNullException(nameof(dependencyObject));

            return dependencyObject.GetValue(IsFocusedProperty) as bool?;
        }

        public static void SetIsFocused(DependencyObject dependencyObject, bool? value)
        {
            _ = dependencyObject ?? throw new ArgumentNullException(nameof(dependencyObject));

            dependencyObject.SetValue(IsFocusedProperty, value);
        }

        private static void IsFocusedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not FrameworkElement element) return;

            var oldValue = args.OldValue;
            var value = GetIsFocused(element);
            if (oldValue == null || (value.HasValue && value.Value))
            {
                element.Loaded += ElementLoaded;
                element.Unloaded += ElementUnloaded;
            }
            else element.Loaded -= ElementLoaded;


            FocusAndMoveCaret(element);
        }

        private static void ElementUnloaded(object sender, RoutedEventArgs e)
        {
            if (sender is not FrameworkElement element) return;
            element.Unloaded -= ElementUnloaded;
            element.Loaded -= ElementLoaded;
        }

        private static void ElementLoaded(object sender, RoutedEventArgs args)
        {
            if (sender is not FrameworkElement element) return;
            FocusAndMoveCaret(element);
        }

        private static void FocusAndMoveCaret(object sender)
        {
            if (sender is not TextBox tb) return;
            tb.Focus();
            Keyboard.Focus(tb);
            tb.CaretIndex = tb.Text.Length;
        }
    }
}
