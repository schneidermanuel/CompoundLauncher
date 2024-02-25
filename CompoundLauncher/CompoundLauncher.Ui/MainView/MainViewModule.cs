using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Ui.MainView;

internal static class MainViewModule
{
    public static void AddMainViewTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<MainViewModel>();
        serviceCollection.AddTransient<IEntryPoint, EntryPoint>();
        serviceCollection.AddTransient<ICompoundItemViewModelFactory, CompoundItemViewModelFactory>();
    }

}