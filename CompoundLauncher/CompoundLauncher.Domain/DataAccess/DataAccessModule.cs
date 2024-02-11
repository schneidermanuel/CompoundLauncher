using CompoundLauncher.Domain.DataAccess.Compounds;
using CompoundLauncher.Domain.DataAccess.FileProvider;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Domain.DataAccess;

public static class DataAccessModule
{
    public static void AddDataAccessTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCompoundTypes();
        serviceCollection.AddFileProviderTypes();
    }
}