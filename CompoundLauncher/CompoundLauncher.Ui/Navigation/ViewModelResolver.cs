using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.Navigation;

public static class ViewModelResolver
{
    private static IServiceProvider? _serviceProvider;

    public static void Setup(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static T Resolve<T>() where T : ViewModelBase
    {
        if (_serviceProvider == null)
        {
            throw new NotSupportedException("The resolver must be initialized before a resolve operation");
        }

        var instance = (T) _serviceProvider.GetService(typeof(T))!;
        return instance;
    }
}