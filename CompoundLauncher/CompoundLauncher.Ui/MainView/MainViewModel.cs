using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Ui.EditCompound;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.MainView;

[ObservableObject]
public partial class MainViewModel : ViewModelBase
{
    [RelayCommand]
    private async Task CreateNew(CancellationToken cancellationToken)
    {
        await NavigationService.NavigateToAsync<EditCompoundViewModel>();
    }
}