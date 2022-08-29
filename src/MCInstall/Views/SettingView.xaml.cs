using MCInstall.Views.Base;
using System;
using System.Windows.Controls;

namespace MCInstall.Views
{
    /// <summary>
    ///     Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl, IView
    {
        public SettingView()
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