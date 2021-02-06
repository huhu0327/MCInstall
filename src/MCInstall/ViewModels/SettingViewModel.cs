using System;
using System.IO;
using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MCInstall.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        private readonly CommonOpenFileDialog _fileDialog = new()
        {
            IsFolderPicker = true,
        };

        private string _minecraftDirectory;

        public string MinecraftDirectory
        {
            get => _minecraftDirectory;
            set => Set(ref _minecraftDirectory, value);
        }

        private bool _isInitMinecraft;

        public bool IsInitMinecraft
        {
            get => _isInitMinecraft;
            set => Set(ref _isInitMinecraft, value);
        }

        private ICommand _positionCommand;
        public ICommand PositionCommand => _positionCommand ??= new ActionCommand(FindFolderDirectory);

        private ICommand _syncGoogleCommand;
        public ICommand SyncGoogleCommand => _syncGoogleCommand ??= new ActionCommand(o => { });

        public SettingViewModel()
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");

            if (!Directory.Exists(directory)) return;

            MinecraftDirectory = directory;
        }


        private void FindFolderDirectory(object o)
        {
            var dialog = _fileDialog;
            dialog.InitialDirectory = MinecraftDirectory;

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;

            MinecraftDirectory = dialog.FileName;
        }
    }
}
