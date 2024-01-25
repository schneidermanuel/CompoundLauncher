using CompoundLauncher.DataAccess.Compounds;
using CompoundLauncher.DataAccess.FileProvider;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.DataAccess;

public static class DataAccessModule
{
    public static void AddDataAccessTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCompoundTypes();
        serviceCollection.AddFileProviderTypes();
    }
}