using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using Keyboard = System.Windows.Input.Keyboard;

namespace MCInstall.Behaviors
{
    public class FocusBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += ElementLoaded;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= ElementLoaded;
            base.OnDetaching();
        }

        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.Register(
                nameof(IsFocused),
                typeof(bool),
                typeof(FocusBehavior),
                new FrameworkPropertyMetadata(false, IsFocusedChanged));

        public bool IsFocused
        {
            get => (bool)GetValue(IsFocusedProperty);
            set => SetValue(IsFocusedProperty, value);
        }

        private static void IsFocusedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not FocusBehavior behavior || !(bool)args.NewValue) return;
            
            behavior.FocusAndMoveCaret(behavior.AssociatedObject);
        }

        private void ElementLoaded(object sender, RoutedEventArgs args)
        {
            if (sender is not FrameworkElement element) return;
            FocusAndMoveCaret(element);
        }

        private void FocusAndMoveCaret(object sender)
        {
            if (sender is not TextBox tb) return;
            tb.Focus();
            Keyboard.Focus(tb);
            tb.CaretIndex = tb.Text.Length;
        }
    }
}
