using MCInstall.Commands;
using MCInstall.ViewModels.Base;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows.Input;

namespace MCInstall.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        private string _minecraftDirectory;
        private ICommand _positionCommand;
        private ICommand _syncGoogleCommand;
        private readonly CommonOpenFileDialog _openFileDialog;

        public SettingViewModel()
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft");

            MinecraftDirectory = Directory.Exists(directory) ? directory : Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            _openFileDialog = new CommonOpenFileDialog { IsFolderPicker = true };
        }

        public string MinecraftDirectory
        {
            get => _minecraftDirectory;
            set
            {
                if (_minecraftDirectory == value || string.IsNullOrEmpty(value)) return;
                InvalidDirectory = !Directory.Exists(value);
                _minecraftDirectory = value;
            }

        }
        public bool InvalidDirectory { get; set; }

        public bool? DirectoryFocused { get; set; }

        public ICommand PositionCommand => _positionCommand ??= new BaseCommand(FindFolderDirectory);
        public ICommand SyncGoogleCommand => _syncGoogleCommand ??= new BaseCommand(_ => { });

        public override void OnEnable()
        {
            DirectoryFocused = true;
        }

        private void FindFolderDirectory(object o)
        {
            DirectoryFocused = false;

            _openFileDialog.InitialDirectory = MinecraftDirectory;
            var result = _openFileDialog.ShowDialog();

            MinecraftDirectory = result switch
            {
                CommonFileDialogResult.Ok => _openFileDialog.FileName,
                CommonFileDialogResult.None or CommonFileDialogResult.Cancel => "",
                _ => throw new ArgumentOutOfRangeException()
            };

            DirectoryFocused = true;
        }

        protected override void Dispose(bool isDisposing)
        {
            if (_disposed) return;

            if (isDisposing)
            {
                _openFileDialog.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}