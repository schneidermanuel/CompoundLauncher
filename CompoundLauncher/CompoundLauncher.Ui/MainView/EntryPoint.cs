using CompoundLauncher.Ui.Navigation;

namespace CompoundLauncher.Ui.MainView;

internal class EntryPoint : IEntryPoint
{
    private readonly INavigationService _navigationService;

    public EntryPoint(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    
    public async Task EnterAsync()
    {
        await _navigationService.NavigateToAsync<MainViewModel>();
    }
}