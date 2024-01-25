using Avalonia.Controls;

namespace CompoundLauncher.Ui.Navigation;

public interface INavigationCore
{
    void DoNavigate(Control view);
}