﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MCInstall.Behaviors
{
    public class DragMoveBehavior
    {
        public static readonly DependencyProperty IsEnableProperty =
            DependencyProperty.RegisterAttached("IsEnable", typeof(bool?), typeof(DragMoveBehavior), new PropertyMetadata(null, OnIsEnabledPropertyChanged));

        public static void SetIsEnable(DependencyObject dependencyObject, bool? value)
        {
            dependencyObject.SetValue(IsEnableProperty, value);
        }

        public static bool? GetIsEnable(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(IsEnableProperty) as bool?;
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is not FrameworkElement element || !(bool)args.NewValue) return;

            element.MouseMove += OnMove;
            element.Unloaded += Unloaded;
        }

        private static void OnMove(object sender, MouseEventArgs args)
        {
            if (sender is not UIElement || args.LeftButton is not MouseButtonState.Pressed) return;

            var window = Application.Current.MainWindow;
            window?.DragMove();
        }

        private static void Unloaded(object sender, RoutedEventArgs args)
        {
            if (sender is not FrameworkElement element) return;

            element.MouseMove -= OnMove;
            element.Unloaded -= Unloaded;
        }
    }
}