using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Ui.EditCompound;

internal static class EditCompoundViewModule
{
    public static void AddEditCompoundTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEditInvokeViewModelFactory, EditInvokeViewModelFactory>();
        serviceCollection.AddTransient<EditCompoundViewModel>();
    }
}