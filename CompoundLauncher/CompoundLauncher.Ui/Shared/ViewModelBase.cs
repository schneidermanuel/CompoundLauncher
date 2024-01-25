using CompoundLauncher.Ui.Navigation;

namespace CompoundLauncher.Ui.Shared;

public class ViewModelBase
{
    public INavigationService NavigationService;

    public void Create(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }
}