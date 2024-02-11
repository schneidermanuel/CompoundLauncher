namespace CompoundLauncher.Domain.Data;

[Serializable]
public class Execute
{
    public string Executable { get; set; }
    public RunType RunType { get; set; }
    public string Args { get; set; }
}