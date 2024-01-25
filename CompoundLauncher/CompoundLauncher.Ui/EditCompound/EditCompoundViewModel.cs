using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.EditCompound;

public class EditCompoundViewModel : ViewModelBase, INavigationAware

{
    public async Task OnNavigatedTo(NavigationContext context)
    {
        await Task.CompletedTask;
    }
}