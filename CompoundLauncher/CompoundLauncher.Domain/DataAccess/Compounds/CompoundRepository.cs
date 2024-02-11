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

    public IReadOnlyList<Compound> RetrieveAllCompoundsAsync()
    {
        var files = _fileProvider.GetCompounds();
        var compounds = files.Select(RetrieveCompoundFromFile).ToArray();
        return compounds;
    }

    private Compound RetrieveCompoundFromFile(string fileName)
    {
        var data = _fileProvider.AccessFileData<Compound>(fileName);
        return data;
    }

    public Compound RetrieveCompoundByGuid(string guid)
    {
        var filename = _fileProvider.GetCompoundFileName(guid);
        return RetrieveCompoundFromFile(filename);
    }

    public async Task SaveCompoundAsync(Compound compound, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(compound.Guid))
        {
            compound.Guid = Guid.NewGuid().ToString();
        }

        var fileName = _fileProvider.GetCompoundFileName(compound.Guid);
        await _fileProvider.StoreData(fileName, compound);
    }
}