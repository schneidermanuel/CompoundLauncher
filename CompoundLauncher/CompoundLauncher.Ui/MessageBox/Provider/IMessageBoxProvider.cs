namespace CompoundLauncher.Ui.MessageBox.Provider;

internal interface IMessageBoxProvider
{
    Task<MessageBoxResult> ShowMessageBoxAsync(string title, string message, MessageBoxButtons messageBoxButtons);
}