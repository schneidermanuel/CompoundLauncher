using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CompoundLauncher.Ui.Navigation;

namespace CompoundLauncher.Ui.Shared;

[ObservableObject]
public partial class ViewModelBase
{
    public bool IsDirty { get; set; }

    private void HandleDirtyIndication(object? sender, PropertyChangedEventArgs e)
    {
        IsDirty = true;
    }

    public INavigationService NavigationService;

    public void Create(INavigationService navigationService)
    {
        this.PropertyChanged += HandleDirtyIndication;
        NavigationService = navigationService;
    }
}