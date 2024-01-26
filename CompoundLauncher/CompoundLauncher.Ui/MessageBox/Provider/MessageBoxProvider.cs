using Avalonia.Controls;

namespace CompoundLauncher.Ui.MessageBox.Provider;

internal class MessageBoxProvider : IMessageBoxProvider
{
    private readonly Window _mainWindow;

    public MessageBoxProvider(Window mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public async Task<MessageBoxResult> ShowMessageBoxAsync(string title, string message, MessageBoxButtons buttons)
    {
        var window = new MessageBoxWindow();
        var vm = new MessageBoxViewModel(res => window.Close(res), buttons)
        {
            Title = title,
            Message = message,
            Icon = "fa-regular fa-circle-question"
        };
        window.DataContext = vm;
        var result = await window.ShowDialog<MessageBoxResult>(_mainWindow);
        return result;
    }
}