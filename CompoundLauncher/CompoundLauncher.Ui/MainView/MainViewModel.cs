using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Ui.EditCompound;
using CompoundLauncher.Ui.Information;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.MainView;

public partial class MainViewModel : ViewModelBase
{
    [RelayCommand]
    private async Task CreateNew(CancellationToken cancellationToken)
    {
        await NavigationService.NavigateToAsync<EditCompoundViewModel>();
    }

    [RelayCommand]
    private async Task ShowInformationAsync(CancellationToken cancellationToken)
    {
        await NavigationService.NavigateToAsync<InformationViewModel>();
    }
}