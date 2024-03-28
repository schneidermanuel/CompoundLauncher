namespace CompoundLauncher.Domain.Launcher;

public interface ICompoundLauncher
{
    Task RunAsync(string guid, CancellationToken cancellationToken);
}