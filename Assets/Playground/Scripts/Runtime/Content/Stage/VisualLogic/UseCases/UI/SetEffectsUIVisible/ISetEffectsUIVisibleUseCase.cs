using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetEffectsUIVisible
{
    public interface ISetEffectsUIVisibleUseCase
    {
        Task Execute(bool visible, bool instantly, CancellationToken cancellationToken);
    }
}
