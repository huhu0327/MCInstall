using MCInstall.Commands;
using MCInstall.ViewModels.Base;

namespace MCInstall.ViewModels
{
    public class DownloadViewModel : BaseViewModel
    {
        public bool IsInitMinecraft { get; set; } = true;
        public bool CanInstallExecute { get; set; }
        public string Code
        {
            get => _code;
            set
            {
                if (_code == value) return;
                _code = value;
                CanInstallExecute = _code.Length > 0;
                InstallCommand.RaiseCanExecuteChanged();
            }
        }
        public IBaseCommand InstallCommand => _installCommand ??= new BaseCommand(_ => { }, _ => CanInstallExecute);

        public DownloadViewModel()
        {
        }

        public override void OnEnable()
        {
        }

        public override void OnDisable()
        {
        }

        private string _code = "";
        private IBaseCommand _installCommand;
    }
}