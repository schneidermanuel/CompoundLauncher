using System.ComponentModel;
using System.Reflection;
using CompoundLauncher.DataAccess.Compounds.Data;

namespace CompoundLauncher.Domain.LaunchTypes;

internal class LaunchTypeProvider : ILaunchTypeProvider
{
    public IReadOnlyCollection<LaunchType> GetAllAvailableLaunchTypes()
    {
        var typeEnums = Enum.GetValues<RunType>();
        var types = typeEnums.Select(t => new LaunchType(GetEnumDescription(t), t.ToString())).ToArray();
        return types;
    }

    private static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}