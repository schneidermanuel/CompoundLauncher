using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Ui.EditCompound;

internal interface IEditInvokeViewModelFactory
{
    EditInvokeViewModel Create(EditCompoundViewModel parent, Execute execute);
    EditInvokeViewModel Create(EditCompoundViewModel parent);
}