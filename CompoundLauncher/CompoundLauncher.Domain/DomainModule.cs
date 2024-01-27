using CompoundLauncher.Domain.LaunchTypes;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Domain;

public static class DomainModule
{
    public static void AddDomainTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ILaunchTypeProvider, LaunchTypeProvider>();
    }
    
}