using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Domain.LaunchTypes;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.EditCompound;

internal partial class EditInvokeViewModel : ViewModelBase
{
    private Window _window;

    public EditInvokeViewModel(Window window, ILaunchTypeProvider launchTypeProvider)
    {
        _window = window;
        AllLaunchTypes = launchTypeProvider.GetAllAvailableLaunchTypes();
    }

    [Required]
    [ObservableProperty]
    private string? _application;

    [ObservableProperty]
    private string? _args;

    [Required]
    [ObservableProperty]
    private LaunchType? _launchType;

    [ObservableProperty]
    private IReadOnlyCollection<LaunchType> _allLaunchTypes;

    [RelayCommand]
    private async Task SelectFileAsync()
    {
        var result = await TopLevel.GetTopLevel(_window)!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            AllowMultiple = false,
            Title = "Select executable"
        });

        if (result.Count == 1)
        {
            var file = result.Single();
            Application = file.Path.AbsolutePath;
        }
    }

    [ObservableProperty]
    private ICommand? _removeInvokeCommand;
}