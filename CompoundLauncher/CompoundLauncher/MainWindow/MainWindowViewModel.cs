using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Ui.Shared;
using ReactiveUI;

namespace CompoundLauncher.MainWindow;

[ObservableObject]
public partial class MainWindowViewModel : ViewModelBase, INavigationCore
{
    [ObservableProperty] private Control _displayedView;

    public void DoNavigate(Control view)
    {
        DisplayedView = view;
    }
}