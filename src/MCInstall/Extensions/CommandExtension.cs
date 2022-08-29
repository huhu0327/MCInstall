using MCInstall.Commands;
using System;
using System.Windows;
using System.Windows.Threading;

namespace MCInstall.Extensions
{
    public static class CommandExtension
    {
        public static void RaiseCanExecuteChangedDispatcher(this IBaseCommand baseCommand)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, baseCommand.RaiseCanExecuteChanged);
        }
    }
}
