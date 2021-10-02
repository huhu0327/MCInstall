using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;

namespace MCInstall.ViewModels
{
    public class DownloadViewModel : BaseViewModel
    {
        private ICommand _installCommand;

        public string Code { get; set; }
        public ICommand InstallCommand => _installCommand ??= new BaseCommand(o => { });

        public bool IsInitMinecraft { get; set; }
    }
}