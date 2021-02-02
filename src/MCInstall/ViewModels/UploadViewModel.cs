using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;

namespace MCInstall.ViewModels
{
    public class UploadViewModel : BaseViewModel
    {
        private string _code;

        public string Code
        {
            get => _code;
            set => Set(ref _code, value);
        }

        private ICommand _uploadCommand;
        public ICommand UploadCommand => _uploadCommand ??= new ActionCommand(o => {});
    }
}