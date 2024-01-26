using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Ui.MainView;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.Information;

internal partial class InformationViewModel : ViewModelBase
{
    [ObservableProperty] private string _applicationVersion = "1.0.0a ";

    [RelayCommand]
    private async Task GoBackAsync(CancellationToken cancellationToken)
    {
        await NavigationService.NavigateToAsync<MainViewModel>();
    }

    [RelayCommand]
    private void OpenGithub()
    {
        Process.Start(new ProcessStartInfo("https://github.com/schneidermanuel") { UseShellExecute = true });
    }
}