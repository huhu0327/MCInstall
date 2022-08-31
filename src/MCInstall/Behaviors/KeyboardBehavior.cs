using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace MCInstall.Behaviors
{
    public class KeyboardBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyDown += OnKeyDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewKeyDown -= OnKeyDown;
            base.OnDetaching();
        }

        public static readonly DependencyProperty IsBlockSpacebarProperty =
            DependencyProperty.Register(
                nameof(IsBlockSpacebar),
                typeof(bool),
                typeof(KeyboardBehavior),
                new PropertyMetadata(false, null));

        public bool IsBlockSpacebar
        {
            get => (bool)GetValue(IsBlockSpacebarProperty);
            set => SetValue(IsBlockSpacebarProperty, value);
        }

        public static readonly DependencyProperty IsBlockKoreanProperty =
            DependencyProperty.Register(
                nameof(IsBlockKorean),
                typeof(bool),
                typeof(KeyboardBehavior),
                new PropertyMetadata(false, null));

        public bool IsBlockKorean
        {
            get => (bool)GetValue(IsBlockKoreanProperty);
            set => SetValue(IsBlockKoreanProperty, value);
        }

        private void OnKeyDown(object sender, KeyEventArgs args)
        {
            var handle = false;

            if (IsBlockSpacebar) handle = args.Key is Key.Space;

            if (IsBlockKorean) handle |= args.Key is Key.ImeProcessed;

            args.Handled = handle;
        }
    }
}