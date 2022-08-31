using MCInstall.ViewModels;
using MCInstall.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MCInstall.Extensions
{
    public static class HostExtension
    {
        public static IHostBuilder ConfigureServices(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton<DownloadViewModel>();
                services.AddSingleton<UploadViewModel>();
                services.AddSingleton<SettingViewModel>();
            });
        }

        public static IHostBuilder ConfigureLog(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((_, configuration) =>
            {
                configuration
                    .WriteTo.Debug()
                    .MinimumLevel.Debug();
            });
        }
    }
}
