using Playground.Content.Stage.Setup;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadStage
{
    public interface ILoadStageUseCase
    {
        Task Execute(StageSetup stageSetup);
    }
}
