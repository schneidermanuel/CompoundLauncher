using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CompoundLauncher.Ui.Shared;

public sealed class BetterObservableCollection<T> : ObservableCollection<T>
{
    public event EventHandler ItemChanged;

    public BetterObservableCollection()
    {
        CollectionChanged += HandleCollectionChanged;
    }

    private void HandleCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        ItemChanged.Invoke(this, e);
        if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
        {
            if (e.OldItems == null)
            {
                return;
            }

            foreach (var item in e.OldItems)
            {
                if (item is INotifyPropertyChanged propertyChanged)
                {
                    propertyChanged.PropertyChanged -= ItemPropertyChanged;
                }
            }
        }

        if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
        {
            foreach (var item in e.NewItems)
            {
                if (item is INotifyPropertyChanged propertyChanged)
                {
                    propertyChanged.PropertyChanged += ItemPropertyChanged;
                }
            }
        }
    }

    private void ItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        ItemChanged.Invoke(this, e);
    }
}