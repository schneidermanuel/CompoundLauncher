using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Domain.Launcher;

internal static class LauncherModule
{

    public static void AddLauncherTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICompoundLauncher, CompoundLauncher>();
    }
}