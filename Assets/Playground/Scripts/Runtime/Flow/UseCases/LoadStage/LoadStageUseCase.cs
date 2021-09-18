using Juce.CoreUnity.Contexts;
using Playground.Content.Stage.Setup;
using Playground.Contexts.Stage;
using Playground.Flow.UseCases.State;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly LastLoadedStageSetupState lastLoadedStageSetupState;

        public LoadStageUseCase(
            LastLoadedStageSetupState lastLoadedStageSetupState
            )
        {
            this.lastLoadedStageSetupState = lastLoadedStageSetupState;
        }

        public Task Execute(StageSetup stageSetup)
        {
            StageContext stageContext = ContextsProvider.GetContext<StageContext>();

            lastLoadedStageSetupState.StageSetup = stageSetup;

            return stageContext.LoadStage(stageSetup);
        }
    }
}
