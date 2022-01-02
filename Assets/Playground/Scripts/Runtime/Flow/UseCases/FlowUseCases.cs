using Playground.Flow.UseCases.LoadLocalizationData;
using Playground.Flow.UseCases.LoadPersistance;
using Playground.Flow.UseCases.LoadStage;
using Playground.Flow.UseCases.ReloadStage;
using Playground.Flow.UseCases.ShowLoadingScreen;

namespace Playground.Flow.UseCases
{
    public class FlowUseCases
    {
        public ILoadPersistanceUseCase LoadPersistanceUseCase { get; }
        public IShowLoadingScreenUseCase ShowLoadingScreenUseCase { get; }
        public ILoadLocalizationDataUseCase LoadLocalizationDataUseCase { get; }
        public ILoadStageUseCase LoadStageUseCase { get; }
        public IReloadStageUseCase ReloadStageUseCase { get; }

        public FlowUseCases(
            ILoadPersistanceUseCase loadPersistanceUseCase,
            IShowLoadingScreenUseCase showLoadingScreenUseCase,
            ILoadLocalizationDataUseCase loadLocalizationDataUseCase,
            ILoadStageUseCase loadStageUseCase,
            IReloadStageUseCase reloadStageUseCase
            )
        {
            LoadPersistanceUseCase = loadPersistanceUseCase;
            ShowLoadingScreenUseCase = showLoadingScreenUseCase;
            LoadLocalizationDataUseCase = loadLocalizationDataUseCase;
            LoadStageUseCase = loadStageUseCase;
            ReloadStageUseCase = reloadStageUseCase;
        }
    }
}
