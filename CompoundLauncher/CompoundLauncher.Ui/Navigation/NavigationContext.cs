namespace CompoundLauncher.Ui.Navigation;

public class NavigationContext
{
    private object[] navigationParams;

    public NavigationContext(object[] navigationParams)
    {
        this.navigationParams = navigationParams;
    }

    public T? GetParameter<T>()
    {
        var firstT = navigationParams.OfType<T>().FirstOrDefault();
        return firstT;
    }
    public T GetSingleParameter<T>()
    {
        var firstT = navigationParams.OfType<T>().FirstOrDefault();
        if (firstT == null)
        {
            throw new ArgumentException($"No Parameter of Type '{typeof(T).FullName}' found");
        }
        return firstT!;
        
    }
}