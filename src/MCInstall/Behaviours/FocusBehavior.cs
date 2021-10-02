using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MCInstall.Behaviours
{
    public static class FocusBehavior
    {
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached("IsFocused", typeof(bool?),
                typeof(FocusBehavior), new FrameworkPropertyMetadata(IsFocusedChanged));
        
        public static void SetIsFocused(DependencyObject dependencyObject, bool? value)
        {
           dependencyObject.SetValue(IsFocusedProperty, value);
        }

        private static void IsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = d as FrameworkElement;

            if (fe is not null && e.OldValue is null && e.NewValue is not null && (bool)e.NewValue)
            {
                fe.Loaded += FrameworkElementLoaded;
            }
        }
        
        private static void FrameworkElementLoaded(object sender, RoutedEventArgs e)
        {
            var fe = sender as FrameworkElement;
            if (fe is not null)
            {
                fe.Loaded -= FrameworkElementLoaded;
                //Keyboard.Focus(fe);
                fe.Focus();
            }
        }
    }
}