using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CompoundLauncher.DataAccess;
using CompoundLauncher.MainWindow;
using CompoundLauncher.Ui;
using CompoundLauncher.Ui.MainView;
using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundLauncher;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var viewModel = new MainWindowViewModel();
            var mainWindow = new Views.MainWindow
            {
                DataContext = viewModel,
            };
            desktop.MainWindow = mainWindow;
            collection.AddSingleton<INavigationCore>(viewModel);
            collection.AddSingleton<Window>(mainWindow);
            collection.AddUiTypes();
            collection.AddDataAccessTypes();
            var serviceProvider = collection.BuildServiceProvider();
            ViewModelResolver.Setup(serviceProvider);
            var navigation = serviceProvider.GetService<INavigationService>();
            _ = navigation!.NavigateToAsync<MainViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}