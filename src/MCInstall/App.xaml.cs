using System.Windows;
using MCInstall.ViewModels;
using MCInstall.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MCInstall
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private readonly ILogger _logger;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices()
                .ConfigureLogging()
                .Build();
            
            _logger = _host.Services.GetRequiredService<ILogger<App>>();
        }


        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var services = _host.Services;

            var window = services.GetRequiredService<MainView>();
#if DEBUG
            window?.Show();
#else
            var programName = Assembly.GetEntryAssembly()?.GetName().Name ?? "program";

            try
            {
                var mutex = new Mutex(true, programName, out var isCreatedNew);

                if (isCreatedNew)
                {
                    window?.Show();
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
#endif

            base.OnStartup(e);
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

    public static class HostExtensions
    {
        public static IHostBuilder ConfigureServices(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MainView>();

                services.AddSingleton<DownloadViewModel>();
                services.AddSingleton<UploadViewModel>();
                services.AddSingleton<SettingViewModel>();
            });
        }

        public static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((context, configuration) =>
            {
                configuration
                    .WriteTo.Debug()
                    .MinimumLevel.Debug();
            });
        }
    }
}