using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Ui.Information;

internal static class InformationModule
{
    public static void AddInformationTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<InformationViewModel>();
    }
}