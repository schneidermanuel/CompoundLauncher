using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Ui.MainView;

internal interface ICompoundItemViewModelFactory
{
    CompoundItemViewModel Create(Compound compound);
}