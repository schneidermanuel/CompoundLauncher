namespace CompoundLauncher.Domain.Data;

[Serializable]
public class Compound
{
    public List<Execute> Components { get; set; }
    public string Name { get; set; }
    public string Guid { get; set; }
}