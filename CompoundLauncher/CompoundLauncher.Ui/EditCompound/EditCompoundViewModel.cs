using System.ComponentModel.DataAnnotations;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Domain.Data;
using CompoundLauncher.Domain.DataAccess.Compounds;
using CompoundLauncher.Domain.LaunchTypes;
using CompoundLauncher.Ui.MainView;
using CompoundLauncher.Ui.MessageBox.Provider;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.EditCompound;

internal partial class EditCompoundViewModel : ViewModelBase
{
    private readonly IMessageBoxProvider _messageBoxProvider;
    private readonly Window _window;
    private readonly ILaunchTypeProvider _launchTypeProvider;
    private readonly ICompoundRepository _repository;

    public EditCompoundViewModel(
        IMessageBoxProvider messageBoxProvider,
        Window window,
        ILaunchTypeProvider launchTypeProvider,
        ICompoundRepository repository)
    {
        Invokes = new BetterObservableCollection<EditInvokeViewModel>();
        Invokes.ItemChanged += (_, _) => OnPropertyChanged(nameof(Invokes));
        _messageBoxProvider = messageBoxProvider;
        _window = window;
        _launchTypeProvider = launchTypeProvider;
        _repository = repository;
    }

    [Required] [ObservableProperty] private string _name;
    private string _guid;
    [ObservableProperty] private BetterObservableCollection<EditInvokeViewModel> _invokes;

    [RelayCommand]
    private void AddInvoke()
    {
        var newInvoke = new EditInvokeViewModel(_window, _launchTypeProvider);
        newInvoke.RemoveInvokeCommand = new RelayCommand(() => Invokes.Remove(newInvoke));
        Invokes.Add(newInvoke);
    }

    [RelayCommand]
    private async Task SaveAsync(CancellationToken cancellationToken)
    {
        var compound = new Compound
        {
            Name = _name,
            Guid = _guid,
            Components = Invokes.Select(invoke =>
            {
                _ = Enum.TryParse<RunType>(invoke.LaunchType.Key, out var runType);
                return new Execute
                {
                    Args = invoke.Args,
                    RunType = runType,
                    Executable = invoke.Application
                };
            }).ToList()
        };
        await _repository.SaveCompoundAsync(compound, cancellationToken);
        await NavigationService.NavigateToAsync<MainViewModel>();
    }

    [RelayCommand]
    private async Task GoBackAsync(CancellationToken cancellationToken)
    {
        if (IsDirty)
        {
            var result = await _messageBoxProvider.ShowMessageBoxAsync("Unsaved changes",
                "There are unsaved changes.\nDo you want to go back?\nAll unsaved changes will be lost!",
                MessageBoxButtons.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }
        }

        await NavigationService.NavigateToAsync<MainViewModel>();
    }
}