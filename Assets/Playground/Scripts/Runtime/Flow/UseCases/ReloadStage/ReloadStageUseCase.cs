using Juce.Core.Loading;
using Playground.Contexts.Stage;
using Playground.Flow.UseCases.LoadStage;
using Playground.Flow.UseCases.ShowLoadingScreen;
using Playground.Flow.UseCases.State;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.ReloadStage
{
    public class ReloadStageUseCase : IReloadStageUseCase
    {
        private readonly LastLoadedStageSetupState lastLoadedStageSetupState;
        private readonly IShowLoadingScreenUseCase showLoadingScreenUseCase;
        private readonly ILoadStageUseCase loadStageUseCase;

        public ReloadStageUseCase(
            LastLoadedStageSetupState lastLoadedStageSetupState,
            IShowLoadingScreenUseCase showLoadingScreenUseCase,
            ILoadStageUseCase loadStageUseCase
            )
        {
            this.lastLoadedStageSetupState = lastLoadedStageSetupState;
            this.showLoadingScreenUseCase = showLoadingScreenUseCase;
            this.loadStageUseCase = loadStageUseCase;
        }

        public async Task Execute()
        {
            ILoadingToken loadingToken = await showLoadingScreenUseCase.Execute();

            await StageContextLoader.Unload();
            await StageUIContextLoader.Unload();

            await StageUIContextLoader.Load();
            await StageContextLoader.Load();

            await loadStageUseCase.Execute(lastLoadedStageSetupState.StageSetup);

            loadingToken.Complete();
        }
    }
}
