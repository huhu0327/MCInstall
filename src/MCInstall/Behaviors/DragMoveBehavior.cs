using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace MCInstall.Behaviors
{
    public class DragMoveBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseMove += OnMove;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= OnMove;

            base.OnDetaching();
        }

        private void OnMove(object sender, MouseEventArgs args)
        {
            if (sender is not UIElement || args.LeftButton is not MouseButtonState.Pressed) return;

            var window = Application.Current.MainWindow;
            window?.DragMove();
        }
    }
}