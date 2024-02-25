using CompoundLauncher.Domain.Data;

namespace CompoundLauncher.Domain.DataAccess.Compounds;

public interface ICompoundRepository
{
    Task<IReadOnlyList<Compound>> RetrieveAllCompoundsAsync();
    Task<Compound> RetrieveCompoundByGuidAsync(string guid);
    Task SaveCompoundAsync(Compound compound, CancellationToken cancellationToken);
    Task DeleteCompoundAsync(string guid, CancellationToken cancellationToken);
}