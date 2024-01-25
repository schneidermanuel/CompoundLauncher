using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.Navigation;

public class NavigationService : INavigationService
{
    private readonly INavigationCore _core;

    public NavigationService(INavigationCore core)
    {
        _core = core;
    }
    public async Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
    {
        var viewModelInstance = ViewModelResolver.Resolve<TViewModel>();
        var view = ViewLocator.CreateView(viewModelInstance);
        _core.DoNavigate(view);
    }
}