using CompoundLauncher.Domain.Validation.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher.Domain.Validation;

internal static class ValidationModule
{
    public static void AddValidationTypes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICompoundValidator, CompoundValidator>();
    }
}