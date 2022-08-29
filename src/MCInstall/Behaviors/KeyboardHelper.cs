using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace MCInstall.Behaviors
{
    public static class KeyboardHelper
    {
        public static readonly DependencyProperty IsBlockSpacebarProperty =
            DependencyProperty.RegisterAttached("IsBlockSpacebar", typeof(bool?), typeof(KeyboardHelper),
                new PropertyMetadata(null, OnTextboxPropertyChanged));

        public static bool? GetIsBlockSpacebar(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(IsBlockSpacebarProperty) as bool?;
        }

        public static void SetIsBlockSpacebar(DependencyObject dependencyObject, bool? value)
        {
            dependencyObject.SetValue(IsBlockSpacebarProperty, value);
        }

        private static void OnTextboxPropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not TextBox textbox || (bool)args.NewValue) return;

            textbox.PreviewKeyDown += OnKeyDown;
            Application.Current.MainWindow!.Closing += (_, _) =>
            {
                textbox.PreviewKeyDown -= OnKeyDown;
            };
        }

        public static readonly DependencyProperty IsBlockKoreanProperty =
            DependencyProperty.RegisterAttached("IsBlockKorean", typeof(bool?), typeof(KeyboardHelper),
                new PropertyMetadata(null, OnTextboxPropertyChanged));

        public static void SetIsBlockKorean(DependencyObject dependencyObject, bool? value)
        {
            dependencyObject.SetValue(IsBlockKoreanProperty, value);
        }

        public static bool? GetIsBlockKorean(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(IsBlockKoreanProperty) as bool?;
        }

        private static void OnKeyDown(object sender, KeyEventArgs args)
        {
            if (sender is not TextBox textBox) return;

            var handle = false;

            var blockedSpacebar = GetIsBlockSpacebar(textBox);
            if (blockedSpacebar.HasValue && blockedSpacebar.Value) handle = args.Key is Key.Space;

            var blockedKorean = GetIsBlockKorean(textBox);
            if (blockedKorean.HasValue && blockedKorean.Value) handle |= args.Key is Key.ImeProcessed;

            args.Handled = handle;
        }
    }
}