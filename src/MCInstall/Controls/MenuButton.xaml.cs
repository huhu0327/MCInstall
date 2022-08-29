using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MCInstall.Controls
{
    /// <summary>
    ///     Interaction logic for TabListItemControl.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(nameof(IsSelected), typeof(bool), typeof(MenuButton));

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(string), typeof(MenuButton), new PropertyMetadata("&#xf108;"));

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register(nameof(IconSize), typeof(double), typeof(MenuButton), new PropertyMetadata(12.0));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(MenuButton), new PropertyMetadata("Menu"));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(MenuButton));

        public new double Height
        {
            get => (double)GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }

        public new static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register(nameof(Height), typeof(double), typeof(MenuButton), new PropertyMetadata((double)32));

        public string GroupName
        {
            get => (string)GetValue(GroupNameProperty);
            set => SetValue(GroupNameProperty, value);
        }

        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register(nameof(GroupName), typeof(string), typeof(MenuButton), new PropertyMetadata("Group"));

    }
}