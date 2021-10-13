using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible
{
    public interface ISetDirectionSelectorUIVisibleUseCase
    {
        Task Execute(bool visible, bool instantly, CancellationToken cancellationToken);
    }
}
