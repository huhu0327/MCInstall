using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;

namespace MCInstall.ViewModels
{
    public class InstallViewModel : BaseViewModel
    {
        private string _code;
        public string Code
        {
            get => _code;
            set => Set(ref _code, value);
        }

        public ICommand InstallCommand => new ActionCommand(o => { });
    }
}
