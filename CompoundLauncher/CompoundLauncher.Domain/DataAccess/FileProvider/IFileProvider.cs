namespace CompoundLauncher.Domain.DataAccess.FileProvider;

internal interface IFileProvider
{
    Task<IReadOnlyCollection<string>> GetCompoundsAsync();
    string GetCompoundFileName(string guid);
    Task<T> AccessFileDataAsync<T>(string fileName);
    Task StoreDataAsync<T>(string fileName, T input);
    Task DeleteFileAsync(string fileName);
}