namespace CompoundLauncher.Domain.LaunchTypes;

public interface ILaunchTypeProvider
{
    IReadOnlyCollection<LaunchType> GetAllAvailableLaunchTypes();
}