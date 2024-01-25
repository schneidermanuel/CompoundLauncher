using System.Xml.Serialization;
using CompoundLauncher.DataAccess.Compounds.Data;
using CompoundLauncher.DataAccess.FileProvider;

namespace CompoundLauncher.DataAccess.Compounds;

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
        using var stream = File.Open(fileName, FileMode.Open);
        var xmlSerializer = new XmlSerializer(typeof(Compound));
        var compound = (Compound)xmlSerializer.Deserialize(stream)!;
        return compound;
    }

    public Compound RetrieveCompoundByGuid(string guid)
    {
        var filename = _fileProvider.GetCompoundFileName(guid);
        return RetrieveCompoundFromFile(filename);
    }
}