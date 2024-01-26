using CompoundLauncher.Ui.EditCompound;
using CompoundLauncher.Ui.Information;
using CompoundLauncher.Ui.MainView;
using CompoundLauncher.Ui.MessageBox.Provider;
using CompoundLauncher.Ui.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Ui;

public static class UiModule
{
    public static void AddUiTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddInformationTypes();
        serviceCollection.AddNavigationTypes();
        serviceCollection.AddMainViewTypes();
        serviceCollection.AddEditCompoundTypes();
        serviceCollection.AddMessageBoxTypes();
    }
}