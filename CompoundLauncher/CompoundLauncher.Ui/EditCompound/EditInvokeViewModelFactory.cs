using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Domain.Data;
using CompoundLauncher.Ui.Navigation;

namespace CompoundLauncher.Ui.EditCompound;

internal class EditInvokeViewModelFactory : IEditInvokeViewModelFactory
{
    private readonly INavigationService _navigationService;

    public EditInvokeViewModelFactory(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public EditInvokeViewModel Create(EditCompoundViewModel parent, Execute execute)
    {
        var viewModel = ViewModelResolver.Resolve<EditInvokeViewModel>();
        viewModel.Create(_navigationService);
        viewModel.Application = execute.Executable;
        viewModel.Args = execute.Args;
        viewModel.LaunchType = viewModel.AllLaunchTypes.Single(t => t.Key == execute.RunType.ToString());
        viewModel.RemoveInvokeCommand = new RelayCommand(() => parent.Invokes.Remove(viewModel));
        viewModel.IsDirty = false;

        return viewModel;
    }

    public EditInvokeViewModel Create(EditCompoundViewModel parent)
    {
        var viewModel = ViewModelResolver.Resolve<EditInvokeViewModel>();
        viewModel.Create(_navigationService);
        viewModel.RemoveInvokeCommand = new RelayCommand(() => parent.Invokes.Remove(viewModel));
        viewModel.IsDirty = false;
        return viewModel;
    }
}