namespace CompoundLauncher.DataAccess.FileProvider;

internal class FileProvider : IFileProvider
{
    public const string CustomCompoundsDirectoryName = "CustomCompounds";

    private string GetApplicationDirectory()
    {
        var appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var compoundLauncherPath = Path.Combine(appdataPath, "BrainySoftware", "CompoundLauncher");
        return compoundLauncherPath;
    }

    public IReadOnlyCollection<string> GetCompounds()
    {
        var files = Directory.GetFiles(Path.Combine(GetApplicationDirectory(), CustomCompoundsDirectoryName));
        return files;
    }

    public string GetCompoundFileName(string guid)
    {
        return Path.Combine(GetApplicationDirectory(), CustomCompoundsDirectoryName, guid + ".cmp");
    }
}