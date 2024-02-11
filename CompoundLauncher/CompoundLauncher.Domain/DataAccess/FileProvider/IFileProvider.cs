namespace CompoundLauncher.Domain.DataAccess.FileProvider;

internal interface IFileProvider
{
    IReadOnlyCollection<string> GetCompounds();
    string GetCompoundFileName(string guid);
    T AccessFileData<T>(string fileName);
    Task StoreData<T>(string fileName, T input);
}