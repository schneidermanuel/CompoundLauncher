namespace CompoundLauncher.DataAccess.Compounds.Data;

[Serializable]
public class Execute
{
    public string Executable { get; set; }
    public RunType RunType { get; set; }
    public string Name { get; set; }
}