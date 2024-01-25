namespace CompoundLauncher.Ui.Navigation;

internal interface INavigationAware
{
    Task OnNavigatedTo(NavigationContext context);
}