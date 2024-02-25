using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.Navigation;

public class NavigationService : INavigationService
{
    private readonly INavigationCore _core;

    public NavigationService(INavigationCore core)
    {
        _core = core;
    }

    public async Task NavigateToAsync<TViewModel>(params object[] navigationParams) where TViewModel : ViewModelBase
    {
        var viewModelInstance = ViewModelResolver.Resolve<TViewModel>();
        viewModelInstance.Create(this);
        var view = ViewLocator.CreateView(viewModelInstance);
        if (viewModelInstance is INavigationAware navigationAware)
        {
            var context = new NavigationContext(navigationParams);
            _ = navigationAware.OnNavigatedTo(context);
        }

        _core.DoNavigate(view);
        await Task.CompletedTask;
    }
}