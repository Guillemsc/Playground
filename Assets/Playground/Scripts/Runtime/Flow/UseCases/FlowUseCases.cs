using Playground.Flow.UseCases.LoadBaseCheats;
using Playground.Flow.UseCases.LoadLoadingScreenContext;
using Playground.Flow.UseCases.LoadLocalizationData;
using Playground.Flow.UseCases.LoadServicesContext;
using Playground.Flow.UseCases.LoadStage;
using Playground.Flow.UseCases.LoadStageContext;
using Playground.Flow.UseCases.ShowLoadingScreen;

namespace Playground.Flow.UseCases
{
    public class FlowUseCases
    {
        public ILoadServicesContextUseCase LoadServicesContextUseCase { get; }
        public ILoadLoadingScreenContextUseCase LoadLoadingScreenContextUseCase { get; }
        public ILoadStageContextUseCase LoadStageContextUseCase { get; }
        public IShowLoadingScreenUseCase ShowLoadingScreenUseCase { get; }
        public ILoadBaseCheatsUseCase LoadBaseCheatsUseCase { get; }
        public ILoadLocalizationDataUseCase LoadLocalizationDataUseCase { get; }
        public ILoadStageUseCase LoadStageUseCase { get; }

        public FlowUseCases(
            ILoadServicesContextUseCase loadServicesContextUseCase,
            ILoadLoadingScreenContextUseCase loadLoadingScreenContextUseCase,
            ILoadStageContextUseCase loadStageContextUseCase,
            IShowLoadingScreenUseCase showLoadingScreenUseCase,
            ILoadBaseCheatsUseCase loadBaseCheatsUseCase,
            ILoadLocalizationDataUseCase loadLocalizationDataUseCase,
            ILoadStageUseCase loadStageUseCase
            )
        {
            LoadServicesContextUseCase = loadServicesContextUseCase;
            LoadLoadingScreenContextUseCase = loadLoadingScreenContextUseCase;
            LoadStageContextUseCase = loadStageContextUseCase;
            ShowLoadingScreenUseCase = showLoadingScreenUseCase;
            LoadBaseCheatsUseCase = loadBaseCheatsUseCase;
            LoadLocalizationDataUseCase = loadLocalizationDataUseCase;
            LoadStageUseCase = loadStageUseCase;
        }
    }
}
