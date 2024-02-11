using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Domain.DataAccess.Compounds;

public interface ICompoundRepository
{
    IReadOnlyList<Compound> RetrieveAllCompoundsAsync();
    Compound RetrieveCompoundByGuid(string guid);
    Task SaveCompoundAsync(Compound compound, CancellationToken cancellationToken);
}