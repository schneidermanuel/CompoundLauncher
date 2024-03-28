using System.Diagnostics;
using CompoundLauncher.Domain.Data;
using CompoundLauncher.Domain.DataAccess.Compounds;

namespace CompoundLauncher.Domain.Launcher;

internal class CompoundLauncher : ICompoundLauncher
{
    private readonly ICompoundRepository _repository;

    public CompoundLauncher(ICompoundRepository repository)
    {
        _repository = repository;
    }
    public async Task RunAsync(string guid, CancellationToken cancellationToken)
    {
        var compound = await _repository.RetrieveCompoundByGuidAsync(guid);
        foreach (var execute in compound.Components)
        {
            var process = new ProcessStartInfo
            {
               Arguments = execute.Args,
               FileName = execute.Executable,
               UseShellExecute = false
            };
            if (execute.RunType == RunType.OpenMinimized)
            {
                process.WindowStyle = ProcessWindowStyle.Minimized;
            }
            Process.Start(process);
        }
    }
}