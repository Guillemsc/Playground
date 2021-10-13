using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.FinishStage
{
    public interface IFinishStageUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
