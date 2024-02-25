using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Domain.Validation.Shared;

internal interface ICompoundValidation
{
    IReadOnlyCollection<ValidationResult> Validate(Compound compound);
}