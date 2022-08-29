using MCInstall.Extensions;
using MCInstall.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MCInstall
{
    public partial class App
    {
        private readonly IHost _host;
        //private readonly ILogger _logger;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices()
                //.ConfigureLog()
                .Build();

            //_logger = _host.Services.GetRequiredService<ILogger<App>>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            //if (IsDuplicatedProcess()) return;

            var mainView = _host.Services.GetRequiredService<MainView>();
            mainView?.Show();

            base.OnStartup(e);
        }

        private static bool IsDuplicatedProcess()
        {
            var programName = Assembly.GetEntryAssembly()?.GetName().Name;

            using Mutex mutex = new (true, programName, out var result);

            result = !result;

            if (result)
            {
                //MessageBox.Show("이미 실행중인 프로그램이 있습니다.", $"{programName} - 실행 중");
                Current.Shutdown();
            }

            return result;
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}