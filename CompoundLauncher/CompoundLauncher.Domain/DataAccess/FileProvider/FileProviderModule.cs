using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Domain.DataAccess.FileProvider;

public static class FileProviderModule
{
    public static void AddFileProviderTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IFileProvider, FileProvider>();
    }
}