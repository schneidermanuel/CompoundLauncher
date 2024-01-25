using CompoundLauncher.DataAccess.Compounds.Data;

namespace CompoundLauncher.DataAccess.Compounds;

public interface ICompoundRepository
{
    IReadOnlyList<Compound> RetrieveAllCompoundsAsync();
    Compound RetrieveCompoundByGuid(string guid);
}