using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;

namespace MCInstall.ViewModels
{
    public class UploadViewModel : BaseViewModel
    {
        private ICommand _uploadCommand;
        public string Code { get; set; }
        public ICommand UploadCommand => _uploadCommand ??= new BaseCommand(o => { });
    }
}