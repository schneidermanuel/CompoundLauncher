using CompoundLauncher.Domain.Data;
using CompoundLauncher.Domain.DataAccess.FileProvider;

namespace CompoundLauncher.Domain.DataAccess.Compounds;

internal class CompoundRepository : ICompoundRepository
{
    private readonly IFileProvider _fileProvider;

    public CompoundRepository(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }

    public async Task<IReadOnlyList<Compound>> RetrieveAllCompoundsAsync()
    {
        var files = await _fileProvider.GetCompoundsAsync();
        var compounds = await Task.WhenAll(files.Select(RetrieveCompoundFromFileAsync));
        return compounds;
    }

    private async Task<Compound> RetrieveCompoundFromFileAsync(string fileName)
    {
        var data = await _fileProvider.AccessFileDataAsync<Compound>(fileName);
        return data;
    }

    public async Task<Compound> RetrieveCompoundByGuidAsync(string guid)
    {
        var filename = _fileProvider.GetCompoundFileName(guid);
        return await RetrieveCompoundFromFileAsync(filename);
    }

    public async Task SaveCompoundAsync(Compound compound, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(compound.Guid))
        {
            compound.Guid = Guid.NewGuid().ToString();
        }

        var fileName = _fileProvider.GetCompoundFileName(compound.Guid);
        await _fileProvider.StoreDataAsync(fileName, compound);
    }

    public async Task DeleteCompoundAsync(string guid, CancellationToken cancellationToken)
    {
        var fileName = _fileProvider.GetCompoundFileName(guid);
        await _fileProvider.DeleteFileAsync(fileName);
    }
}