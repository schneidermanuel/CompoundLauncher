using CompoundLauncher.Domain.Data;
using CompoundLauncher.Domain.Validation.Shared;

namespace CompoundLauncher.Domain.Validation.Rules;

public class FileMustExistValidationRule : ICompoundValidation
{
    public IReadOnlyCollection<ValidationResult> Validate(Compound compound)
    {
        var validations = new List<ValidationResult>();
        foreach (var component in compound.Components)
        {
            if (!File.Exists(component.Executable))
            {
                validations.Add(new ValidationResult(ValidationResultType.Warning, $"The file '{component.Executable}' could not be found"));
            }
        }

        return validations;
    }
}