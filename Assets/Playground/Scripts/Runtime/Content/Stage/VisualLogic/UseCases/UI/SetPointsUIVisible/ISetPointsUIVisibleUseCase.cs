using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetPointsUIVisible
{
    public interface ISetPointsUIVisibleUseCase
    {
        Task Execute(bool visible, bool instantly, CancellationToken cancellationToken);
    }
}
