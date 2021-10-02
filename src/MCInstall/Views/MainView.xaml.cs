using System.Windows;
using MCInstall.ViewModels;
using MCInstall.ViewModels.Base;
using MCInstall.Views.Base;
using Microsoft.Extensions.Logging;

namespace MCInstall.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window, IView
    {
        public MainView(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}