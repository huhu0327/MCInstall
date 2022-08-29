using System;
using System.Diagnostics;
using MCInstall.Views.Base;
using System.Windows;

namespace MCInstall.Views
{
    public partial class MainView : Window, IView
    {
        public MainView()
        {
            InitializeComponent();

            Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
        }

        private void Dispatcher_ShutdownStarted(object sender, System.EventArgs e)
        {
            Dispatcher.ShutdownStarted -= Dispatcher_ShutdownStarted;
            if (DataContext is not IDisposable disposable) return;
            disposable.Dispose();
        }
    }
}