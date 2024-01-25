using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.Navigation;

public interface INavigationService
{
    Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
}