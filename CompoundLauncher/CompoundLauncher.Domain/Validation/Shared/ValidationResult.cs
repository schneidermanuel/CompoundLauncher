namespace CompoundLauncher.Domain.Validation.Shared;

public class ValidationResult
{
    public ValidationResultType Result { get; }
    public string Message { get; }

    public ValidationResult(
        ValidationResultType result,
        string message)
    {
        Result = result;
        Message = message;
    }
}