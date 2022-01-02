using Playground.Content.Stage.Setup;
using Playground.Content.Stage.UseCases.StageFinished;
using System.Threading.Tasks;

namespace Playground.Contexts.Stage
{
    public interface IStageContext 
    {
        Task LoadStage(StageSetup stageSetup, IStageFinishedUseCase stageFinishedUseCase);
    }
}
