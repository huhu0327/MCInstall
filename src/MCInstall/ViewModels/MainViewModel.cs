using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;
using MCInstall.Views;

namespace MCInstall.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly DownloadViewModel _downloadViewModel;
        private readonly UploadViewModel _uploadViewModel;
        private readonly SettingViewModel _settingViewModel;


        public MainWindowViewModel(DownloadViewModel downloadViewModel, UploadViewModel uploadViewModel, SettingViewModel settingViewModel)
        {
            _downloadViewModel = downloadViewModel;
            _uploadViewModel = uploadViewModel;
            _settingViewModel = settingViewModel;
            
            View = _downloadViewModel;
        }

        public IViewModel View { get; set; }

        public ICommand ClickDownloadMenu => new BaseCommand(ShowDownloadView);
        public ICommand ClickUploadMenu => new BaseCommand(ShowUploadView);
        public ICommand ClickSettingMenu => new BaseCommand(ShowSettingView);

        private void ShowDownloadView(object o)
        {
            View = _downloadViewModel;
        }
        
        private void ShowUploadView(object o)
        {
            View = _uploadViewModel;
        }
        
        private void ShowSettingView(object o)
        {
            View = _settingViewModel;
        }
    }
}