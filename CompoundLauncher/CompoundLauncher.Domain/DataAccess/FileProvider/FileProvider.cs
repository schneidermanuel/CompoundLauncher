using System.Xml.Serialization;

namespace CompoundLauncher.Domain.DataAccess.FileProvider;

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

    public T AccessFileData<T>(string fileName)
    {
        using var stream = File.Open(fileName, FileMode.Open);
        var xmlSerializer = new XmlSerializer(typeof(T));
        var loaded = (T)xmlSerializer.Deserialize(stream)!;
        return loaded;
    }

    public async Task StoreData<T>(string fileName, T input)
    {
        var path = Path.GetDirectoryName(fileName);
        Directory.CreateDirectory(path);
        var stream = File.Open(fileName, FileMode.Create);
        var xmlSerializer = new XmlSerializer(typeof(T));
        xmlSerializer.Serialize(stream, input);
        await Task.CompletedTask;
    }
}