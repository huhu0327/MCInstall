using System.Windows.Input;
using MCInstall.Commands;
using MCInstall.ViewModels.Base;

namespace MCInstall.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
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
        public ICommand PositionCommand => _positionCommand ??= new ActionCommand(o => { });

        private ICommand _syncGoogleCommand;
        public ICommand SyncGoogleCommand => _syncGoogleCommand ??= new ActionCommand(o => { });

    }
}
