using Avalonia.Controls;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.Navigation;

public static class ViewLocator
{
    public static Control CreateView(ViewModelBase viewModel)
    {
        var name = viewModel.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null)
        {
            var control = (UserControl)Activator.CreateInstance(type)!;
            control.DataContext = viewModel;
            return control;
        }

        return new TextBlock { Text = "View not Found: " + name };
    }
}