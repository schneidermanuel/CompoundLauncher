using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.MainWindow;

public partial class MainWindowViewModel : ViewModelBase, INavigationCore
{
    [ObservableProperty] private Control _displayedView;

    public void DoNavigate(Control view)
    {
        DisplayedView = view;
    }
}