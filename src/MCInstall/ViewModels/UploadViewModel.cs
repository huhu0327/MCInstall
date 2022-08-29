using MCInstall.Commands;
using MCInstall.ViewModels.Base;
using System.Windows.Input;

namespace MCInstall.ViewModels
{
    public class UploadViewModel : BaseViewModel
    {
        

        public string Code { get; set; } = "-";
        public bool ErrorSentenceEnable { get; set; }
        public bool CanUploadExecute { get; set; }
        public ICommand UploadCommand => _uploadCommand ??= new BaseCommand(Upload, ExecuteUpload);

        public UploadViewModel()
        {
            
        }

        private ICommand _uploadCommand;
        private void Upload(object o)
        {

        }

        private bool ExecuteUpload(object o)
        {
            var result = CanUploadExecute;

            ErrorSentenceEnable = !result;

            return result;
        }
    }
}