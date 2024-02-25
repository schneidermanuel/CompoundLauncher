using CompoundLauncher.Domain.DataAccess;
using CompoundLauncher.Domain.LaunchTypes;
using CompoundLauncher.Domain.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Domain;

public static class DomainModule
{
    public static void AddDomainTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDataAccessTypes();
        serviceCollection.AddValidationTypes();
        serviceCollection.AddTransient<ILaunchTypeProvider, LaunchTypeProvider>();
    }
    
}