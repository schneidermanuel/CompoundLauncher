using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Ui.EditCompound;

internal interface IEditInvokeViewModelFactory
{
    EditInvokeViewModel Create(Execute execute);
}