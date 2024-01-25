using CompoundLauncher.Ui.EditCompound;
using CompoundLauncher.Ui.MainView;
using CompoundLauncher.Ui.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Ui;

public static class UiModule
{
    public static void AddUiTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddNavigationTypes();
        serviceCollection.AddMainViewTypes();
        serviceCollection.AddEditCompoundTypes();
    }
}