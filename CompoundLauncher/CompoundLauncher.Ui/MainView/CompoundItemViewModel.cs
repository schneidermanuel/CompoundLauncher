using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Domain.DataAccess.Compounds;
using CompoundLauncher.Domain.Launcher;
using CompoundLauncher.Ui.EditCompound;
using CompoundLauncher.Ui.MessageBox.Provider;
using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.MainView;

internal partial class CompoundItemViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly ICompoundRepository _repository;
    private readonly IMessageBoxProvider _messageBoxProvider;
    private readonly ICompoundLauncher _compoundLauncher;

    [ObservableProperty] private string _guid;
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _invokes;

    public CompoundItemViewModel(
        INavigationService navigationService,
        ICompoundRepository repository,
        IMessageBoxProvider messageBoxProvider,
        ICompoundLauncher compoundLauncher
    )
    {
        _navigationService = navigationService;
        _repository = repository;
        _messageBoxProvider = messageBoxProvider;
        _compoundLauncher = compoundLauncher;
    }

    [RelayCommand]
    private async Task ShowItemAsync(CancellationToken cancellationToken)
    {
        await _navigationService.NavigateToAsync<EditCompoundViewModel>(Guid);
    }

    [RelayCommand]
    private async Task DeleteItemAsync(CancellationToken cancellationToken)
    {
        var result = await _messageBoxProvider.ShowMessageBoxAsync("Delete Compound?",
            $"Do you wish to delete the Compound '{Name}'\nThis can not be undone!", MessageBoxButtons.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            await _repository.DeleteCompoundAsync(Guid, cancellationToken);
            await _navigationService.NavigateToAsync<MainViewModel>();
        }
    }

    [RelayCommand]
    private async Task OpenCompoundAsync(CancellationToken cancellationToken)
    {
        await _compoundLauncher.RunAsync(_guid, cancellationToken);
    }
}