using System.ComponentModel.DataAnnotations;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Domain.Data;
using CompoundLauncher.Domain.DataAccess.Compounds;
using CompoundLauncher.Domain.LaunchTypes;
using CompoundLauncher.Ui.MainView;
using CompoundLauncher.Ui.MessageBox.Provider;
using CompoundLauncher.Ui.Navigation;
using CompoundLauncher.Ui.Shared;
using DynamicData;

namespace CompoundLauncher.Ui.EditCompound;

internal partial class EditCompoundViewModel : ViewModelBase, INavigationAware
{
    private readonly IMessageBoxProvider _messageBoxProvider;
    private readonly Window _window;
    private readonly ILaunchTypeProvider _launchTypeProvider;
    private readonly ICompoundRepository _repository;
    private readonly IEditInvokeViewModelFactory _editInvokeViewModelFactory;

    public EditCompoundViewModel(
        IMessageBoxProvider messageBoxProvider,
        Window window,
        ILaunchTypeProvider launchTypeProvider,
        ICompoundRepository repository,
        IEditInvokeViewModelFactory editInvokeViewModelFactory)
    {
        Invokes = new BetterObservableCollection<EditInvokeViewModel>();
        Invokes.ItemChanged += (_, _) => OnPropertyChanged(nameof(Invokes));
        _messageBoxProvider = messageBoxProvider;
        _window = window;
        _launchTypeProvider = launchTypeProvider;
        _repository = repository;
        _editInvokeViewModelFactory = editInvokeViewModelFactory;
    }

    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [Required]
    [ObservableProperty]
    private string? _name;

    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [ObservableProperty]
    private string? _description;

    private string? _guid;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private BetterObservableCollection<EditInvokeViewModel> _invokes;

    private bool _isDirty;

    public override bool IsDirty
    {
        get => _isDirty;
        set
        {
            _isDirty = value;
            SaveCommand.NotifyCanExecuteChanged();
            ResetCommand.NotifyCanExecuteChanged();
        }
    }


    [RelayCommand(CanExecute = nameof(CanReset))]
    private async Task ResetAsync()
    {
        if (!string.IsNullOrEmpty(_guid))
        {
            await InitializeAsync(_guid);
        }
        else
        {
            Invokes.Clear();
            Name = null;
            Description = null;
        }
    }

    private bool CanReset()
    {
        return IsDirty;
    }

    [RelayCommand]
    private void AddInvoke()
    {
        var newInvoke = _editInvokeViewModelFactory.Create(this);
        newInvoke.RemoveInvokeCommand = new RelayCommand(() => Invokes.Remove(newInvoke));
        Invokes.Add(newInvoke);
    }

    private bool CanSave()
    {
        return IsDirty && !HasErrors && Invokes.All(i => !i.HasErrors);
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync(CancellationToken cancellationToken)
    {
        var compound = new Compound
        {
            Name = Name,
            Guid = _guid,
            Description = Description,
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

    public async Task OnNavigatedTo(NavigationContext context)
    {
        var guid = context.GetParameter<string>();
        if (!string.IsNullOrEmpty(guid))
        {
            await InitializeAsync(guid);
        }
    }

    private async Task InitializeAsync(string guid)
    {
        var compound = await _repository.RetrieveCompoundByGuidAsync(guid);
        Name = compound.Name;
        Description = compound.Description;
        _guid = guid;
        var invokes = compound.Components.Select(item => _editInvokeViewModelFactory.Create(this, item));
        Invokes.Clear();
        Invokes.AddRange(invokes);
        IsDirty = false;
    }
}