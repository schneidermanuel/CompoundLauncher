using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Domain.Validation.Shared;

internal class CompoundValidator : ICompoundValidator
{
    private readonly IReadOnlyCollection<ICompoundValidation> _validationItems;

    public CompoundValidator(IEnumerable<ICompoundValidation> validationItems)
    {
        _validationItems = validationItems.ToArray();
    }

    public IReadOnlyCollection<ValidationResult> Validate(Compound compound)
    {
        var results = _validationItems.SelectMany(item => item.Validate(compound)).ToArray();
        return results;
    }
}