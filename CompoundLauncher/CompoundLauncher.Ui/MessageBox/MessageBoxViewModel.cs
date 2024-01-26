using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompoundLauncher.Ui.MessageBox.Provider;
using CompoundLauncher.Ui.Shared;

namespace CompoundLauncher.Ui.MessageBox;

[ObservableObject]
internal partial class MessageBoxViewModel
{
    private readonly Action<MessageBoxResult> _close;

    public MessageBoxViewModel(Action<MessageBoxResult> close, MessageBoxButtons buttons)
    {
        _close = close;
        switch (buttons)
        {
            case MessageBoxButtons.YesNo:
                YesButtonVisible = true;
                NoButtonVisible = true;
                break;
            case MessageBoxButtons.YesNoCancel:
                YesButtonVisible = true;
                NoButtonVisible = true;
                CancelButtonVisible = true;
                break;
            case MessageBoxButtons.Ok:
                OkButtonVisible = true;
                break;
            case MessageBoxButtons.OkCancel:
                OkButtonVisible = true;
                CancelButtonVisible = true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(buttons), buttons, null);
        }
    }

    [ObservableProperty] private string _title;
    [ObservableProperty] private string _message;
    [ObservableProperty] private string _icon;

    [ObservableProperty] private bool _okButtonVisible;
    [ObservableProperty] private bool _yesButtonVisible;
    [ObservableProperty] private bool _noButtonVisible;
    [ObservableProperty] private bool _cancelButtonVisible;

    [RelayCommand]
    private void Ok()
    {
        _close(MessageBoxResult.Ok);
    }

    [RelayCommand]
    private void Cancel()
    {
        _close(MessageBoxResult.Cancel);
    }

    [RelayCommand]
    private void Yes()
    {
        _close(MessageBoxResult.Yes);
    }

    [RelayCommand]
    private void No()
    {
        _close(MessageBoxResult.No);
    }
}