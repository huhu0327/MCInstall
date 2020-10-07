using Prism.Mvvm;

namespace MCInstall.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "MCInstall";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
