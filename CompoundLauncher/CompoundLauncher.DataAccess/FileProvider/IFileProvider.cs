namespace CompoundLauncher.DataAccess.FileProvider;

internal interface IFileProvider
{
    IReadOnlyCollection<string> GetCompounds();
    string GetCompoundFileName(string guid);
}