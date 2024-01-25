using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Ui.Navigation;

internal static class UiNavigationModule
{
    public static void AddNavigationTypes(this IServiceCollection collection)
    {
        collection.AddTransient<INavigationService, NavigationService>();
    }
}