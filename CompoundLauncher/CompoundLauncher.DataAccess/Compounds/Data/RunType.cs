using System.ComponentModel;

namespace CompoundLauncher.DataAccess.Compounds.Data;

[Serializable]
public enum RunType
{
    [Description("Open")]
    Open,
    [Description("Open minimized")]
    OpenMinimized
}