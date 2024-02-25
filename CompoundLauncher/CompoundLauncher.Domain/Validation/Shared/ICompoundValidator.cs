using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Domain.Validation.Shared;

public interface ICompoundValidator
{
    IReadOnlyCollection<ValidationResult> Validate(Compound compound);
}