
using MahApps.Metro.IconPacks;
using MCInstall.Controls;
using MCInstall.Views;
using System.Collections.Generic;
using System.Reflection;

namespace MCInstall.ViewModels
{
    public class MainWindowViewModel : Base.BaseViewModel
    {
        public string Title { get; } = Assembly.GetEntryAssembly()?.GetName().Name ?? "MCInstall";

        public List<IconTabItem> TabItems { get; }
            = new ()  {
            new IconTabItem() { Header = "설치", Content = new InstallView(), Icon = PackIconFontAwesomeKind.FileArchiveSolid },
            new IconTabItem() { Header = "업로드", Content = new UploadView(), Icon = PackIconFontAwesomeKind.CloudUploadAltSolid },
            new IconTabItem() { Header = "설정", Content = new SettingView(), Icon = PackIconFontAwesomeKind.SlidersHSolid },
        };

    }
}
