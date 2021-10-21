using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetMainStageUIVisible
{
    public interface ISetMainStageUIVisibleUseCase
    {
        Task Execute(bool visible, bool instantly, CancellationToken cancellationToken);
    }
}
