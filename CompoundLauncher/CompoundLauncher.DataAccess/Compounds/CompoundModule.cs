using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.DataAccess.Compounds;

internal static class CompoundModule
{
    public static void AddCompoundTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICompoundRepository, CompoundRepository>();
    }
}