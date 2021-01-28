using MCInstall.Views;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace MCInstall
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

#if RELEASE
            var programName = Assembly.GetEntryAssembly()?.GetName().Name ?? "program";

            try
            {
                var mutex = new Mutex(true, programName, out var isCreatedNew);

                if (isCreatedNew)
                {
                    MainWindow = new MainWindow();
                    MainWindow?.Show();
                    return;
                }
            }
            catch (Exception ex)
            {
                //TODO: 프로그램 실행 예외 로그 수집
                Shutdown();
            }

            MessageBox.Show("이미 실행중인 프로그램이 있습니다.", $"{programName} - 실행 중");
            Shutdown();
#else
            MainWindow = new MainWindow();
            MainWindow?.Show();
#endif
        }
    }

}
