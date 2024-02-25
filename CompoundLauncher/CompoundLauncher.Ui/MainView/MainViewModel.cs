using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Domain.DataAccess.Compounds;
using CompoundLauncher.Ui.EditCompound;
using CompoundLauncher.Ui.Information;
using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Ui.Shared;
using DynamicData;

namespace CompoundLauncher.Ui.MainView;

internal partial class MainViewModel : ViewModelBase, INavigationAware
{
    private readonly ICompoundRepository _repository;
    private readonly ICompoundItemViewModelFactory _factory;

    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private BetterObservableCollection<CompoundItemViewModel> _items;

    public MainViewModel(ICompoundRepository repository,
        ICompoundItemViewModelFactory factory)
    {
        _repository = repository;
        _factory = factory;
        _isLoading = true;
        Items = new BetterObservableCollection<CompoundItemViewModel>();
        Items.ItemChanged += (_, _) => OnPropertyChanged(nameof(Items));
    }

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

    public async Task OnNavigatedTo(NavigationContext context)
    {
        IsLoading = true;
        var items = await _repository.RetrieveAllCompoundsAsync();
        Items.AddRange(items.Select(_factory.Create));
        IsLoading = false;
    }
}