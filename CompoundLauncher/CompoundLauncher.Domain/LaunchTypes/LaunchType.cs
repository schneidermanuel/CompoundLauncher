namespace CompoundLauncher.Domain.LaunchTypes;

public class LaunchType
{
    public string DisplayName { get; }
    public string Key { get; }

    public LaunchType(string displayName, string key)
    {
        DisplayName = displayName;
        Key = key;
    }
}