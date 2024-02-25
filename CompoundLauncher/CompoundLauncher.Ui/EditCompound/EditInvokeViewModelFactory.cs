using Avalonia.Controls;
using CompoundLauncher.Domain.Data;
using CompoundLauncher.Domain.LaunchTypes;

namespace CompoundLauncher.Ui.EditCompound;

internal class EditInvokeViewModelFactory : IEditInvokeViewModelFactory
{
    private readonly Window _window;
    private readonly ILaunchTypeProvider _launchTypeProvider;

    public EditInvokeViewModelFactory(Window window, ILaunchTypeProvider launchTypeProvider)
    {
        _window = window;
        _launchTypeProvider = launchTypeProvider;
    }

    public EditInvokeViewModel Create(Execute execute)
    {
        var viewModel = new EditInvokeViewModel(_window, _launchTypeProvider)
        {
            
        };
        
        return viewModel;
    }
}