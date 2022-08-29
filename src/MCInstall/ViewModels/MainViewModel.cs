using MCInstall.Commands;
using MCInstall.ViewModels.Base;
using System.Windows.Input;

namespace MCInstall.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IBaseViewModel _downloadViewModel;
        private readonly IBaseViewModel _uploadViewModel;
        private readonly IBaseViewModel _settingViewModel;

        public MainWindowViewModel(DownloadViewModel downloadViewModel, UploadViewModel uploadViewModel, SettingViewModel settingViewModel)
        {
            _downloadViewModel = downloadViewModel;
            _uploadViewModel = uploadViewModel;
            _settingViewModel = settingViewModel;

            ViewModel = _downloadViewModel;
        }

        public IBaseViewModel ViewModel { get; set; }

        public ICommand ClickDownloadMenu => new BaseCommand(_ => ChangeView(_downloadViewModel));
        public ICommand ClickUploadMenu => new BaseCommand(_ =>ChangeView(_uploadViewModel));
        public ICommand ClickSettingMenu => new BaseCommand(_ => ChangeView(_settingViewModel));

        protected override void Dispose(bool isDisposing)
        {
            if (_disposed) return;

            if (isDisposing)
            {

            }

            base.Dispose(isDisposing);
        }

        private void ChangeView(IBaseViewModel viewModel)
        {
            ViewModel.OnDisable();
            ViewModel = viewModel;
            ViewModel.OnEnable();
        }


    }
}