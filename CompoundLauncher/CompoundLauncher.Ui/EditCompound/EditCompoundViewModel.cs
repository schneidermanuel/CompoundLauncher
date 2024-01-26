using System.ComponentModel;
using Avalonia.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Ui.MainView;
using CompoundLauncher.Ui.MessageBox.Provider;
using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.EditCompound;

internal partial class EditCompoundViewModel : ViewModelBase, INavigationAware
{
    private readonly IMessageBoxProvider _messageBoxProvider;

    public EditCompoundViewModel(IMessageBoxProvider messageBoxProvider)
    {
        _messageBoxProvider = messageBoxProvider;
    }

    [ObservableProperty] private string _name;

    [RelayCommand]
    private async Task GoBackAsync(CancellationToken cancellationToken)
    {
        if (IsDirty)
        {
            var result = await _messageBoxProvider.ShowMessageBoxAsync("Unsaved changes",
                "There are unsaved changes.\nDo you want to go back?\nAll unsaved changes will be lost!",
                MessageBoxButtons.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }
        }

        await NavigationService.NavigateToAsync<MainViewModel>();
    }

    public async Task OnNavigatedTo(NavigationContext context)
    {
        await Task.CompletedTask;
    }
}