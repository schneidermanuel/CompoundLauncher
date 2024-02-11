using System.ComponentModel;

namespace CompoundLauncher.Domain.Data;

[Serializable]
public enum RunType
{
    [Description("Open")]
    Open,
    [Description("Open minimized")]
    OpenMinimized
}