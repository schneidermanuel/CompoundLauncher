using System.ComponentModel;
using System.Reflection;

namespace CompoundLauncher.Domain.LaunchTypes;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString())!;

        DescriptionAttribute[] attributes =
            (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[])!;

        if (attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}