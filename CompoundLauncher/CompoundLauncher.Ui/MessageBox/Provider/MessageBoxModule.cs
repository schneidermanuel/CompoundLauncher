using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Ui.MessageBox.Provider;

internal static class MessageBoxModule
{
    public static void AddMessageBoxTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IMessageBoxProvider, MessageBoxProvider>();
    }
}