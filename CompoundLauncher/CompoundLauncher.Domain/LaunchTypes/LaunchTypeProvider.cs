using System.ComponentModel;
using System.Reflection;
using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Domain.LaunchTypes;

internal class LaunchTypeProvider : ILaunchTypeProvider
{
    public IReadOnlyCollection<LaunchType> GetAllAvailableLaunchTypes()
    {
        var typeEnums = Enum.GetValues<RunType>();
        var types = typeEnums.Select(t => new LaunchType(t.GetDescription(), t.ToString())).ToArray();
        return types;
    }

}