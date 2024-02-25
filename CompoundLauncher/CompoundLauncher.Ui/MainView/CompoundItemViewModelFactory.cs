using System.Text;
using CompoundLauncher.Domain.Data;
using CompoundLauncher.Domain.DataAccess.Compounds;
using CompoundLauncher.Ui.MessageBox.Provider;
using CompoundLauncher.Ui.Navigation;

namespace CompoundLauncher.Ui.MainView;

internal class CompoundItemViewModelFactory : ICompoundItemViewModelFactory
{
    private readonly INavigationService _navigationService;
    private readonly ICompoundRepository _repository;
    private readonly IMessageBoxProvider _messageBoxProvider;

    public CompoundItemViewModelFactory(
        INavigationService navigationService,
        ICompoundRepository repository,
        IMessageBoxProvider messageBoxProvider)
    {
        _navigationService = navigationService;
        _repository = repository;
        _messageBoxProvider = messageBoxProvider;
    }

    public CompoundItemViewModel Create(Compound compound)
    {
        var builder = new StringBuilder();
        var invokes = compound.Components.Take(3);
        foreach (var invoke in invokes)
        {
            builder.AppendLine(Path.GetFileName(invoke.Executable));
        }

        var moreCount = compound.Components.Count - 3;
        if (moreCount > 0)
        {
            builder.AppendLine("+ " + moreCount + " others");
        }

        var viewModel = new CompoundItemViewModel(_navigationService, _repository, _messageBoxProvider)
        {
            Guid = compound.Guid,
            Name = compound.Name,
            Description = compound.Description,
            Invokes = builder.ToString()
        };
        return viewModel;
    }
}