using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CompoundLauncher.Ui.Navigation;

namespace CompoundLauncher.Ui.Shared;

public class ViewModelBase : ObservableValidator
{
    public virtual bool IsDirty { get; set; }

    private void HandleDirtyIndication(object? sender, PropertyChangedEventArgs e)
    {
        IsDirty = true;
        ValidateAllProperties();
    }

    public INavigationService NavigationService;

    public void Create(INavigationService navigationService)
    {
        PropertyChanged += HandleDirtyIndication;
        NavigationService = navigationService;
        ValidateAllProperties();
    }
}