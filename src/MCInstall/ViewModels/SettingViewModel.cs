using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MCInstall.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        private ICommand _positionCommand;
        private ICommand _syncGoogleCommand;

        public SettingViewModel()
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft");

            if (!Directory.Exists(directory)) return;

            MinecraftDirectory = directory;
        }


        public string MinecraftDirectory { get; set; }

        public ICommand PositionCommand => _positionCommand ??= new BaseCommand(FindFolderDirectory);
        public ICommand SyncGoogleCommand => _syncGoogleCommand ??= new BaseCommand(o => { });

        private async void FindFolderDirectory(object o)
        {
            MinecraftDirectory = await GetFolderDirectoryAsync();
        }

        private Task<string> GetFolderDirectoryAsync()
        {
            var currentDirectory = MinecraftDirectory;

            var dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                InitialDirectory = currentDirectory,
            };

            if (dialog.ShowDialog() is CommonFileDialogResult.Ok)
            {
                currentDirectory = dialog.FileName;
            }

            return Task.FromResult(currentDirectory);
        }
    }
}