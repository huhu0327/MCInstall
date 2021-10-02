using System.ComponentModel;

namespace MCInstall.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged , IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, _) => { };
    }

    public interface IViewModel { }
}