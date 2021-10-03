using System.Threading.Tasks;
using UnityEngine;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using Playground.Services;
using Playground.Flow.UseCases;
using Playground.Flow.UseCases.LoadServicesContext;
using Playground.Flow.UseCases.LoadBaseCheats;
using Playground.Flow.UseCases.LoadLocalizationData;
using Playground.Flow.UseCases.LoadLoadingScreenContext;
using Playground.Flow.UseCases.ShowLoadingScreen;
using Playground.Flow.UseCases.LoadStageContext;
using Playground.Flow.UseCases.LoadStage;
using Playground.Flow.UseCases.LoadCamerasContext;
using Playground.Flow.UseCases.LoadStageUIContext;
using Playground.Flow.UseCases.ReloadStage;
using Playground.Content.Stage.Setup;
using Playground.Configuration.Stage;
using Playground.Flow.UseCases.State;
using Playground.Flow.UseCases.LoadMetaContext;

namespace Playground.Boostraps
{
    public class MainBootstrap : MonoBehaviour
    {
        [SerializeField] private StageConfiguration defaultStageConfiguration = default;

        private void Awake()
        {
            Run().RunAsync();
        }

        private async Task Run()
        {
            GenerateFlowService();

            FlowService flowService = ServicesProvider.GetService<FlowService>();
            FlowUseCases flowUseCases = flowService.FlowUseCases;

            await flowUseCases.LoadServicesContextUseCase.Execute();
            await flowUseCases.LoadLoadingScreenContextUseCase.Execute();
            await flowUseCases.LoadCamerasContextUseCase.Execute();

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenUseCase.Execute();

            flowUseCases.LoadBaseCheatsUseCase.Execute();

            await flowUseCases.LoadLocalizationDataUseCase.Execute();

            await flowUseCases.LoadMetaContextUseCase.Execute();
            await flowUseCases.LoadStageUIContextUseCase.Execute();
            await flowUseCases.LoadStageContextUseCase.Execute();

            StageSetup stageSetup = defaultStageConfiguration.ToSetup();

            await flowUseCases.LoadStageUseCase.Execute(stageSetup);

            loadingToken.Complete();

            //await flowUseCases.LoadUserDataFlowUseCase.Execute();

            //await flowUseCases.LoadAdsScenesFlowUseCase.Execute();
        }

        private void GenerateFlowService()
        {
            LastLoadedStageSetupState lastLoadedStageSetupState = new LastLoadedStageSetupState();

            ILoadServicesContextUseCase loadServicesContextUseCase = new LoadServicesContextUseCase();

            ILoadCamerasContextUseCase loadCamerasContextUseCase = new LoadCamerasContextUseCase();

            ILoadLoadingScreenContextUseCase loadLoadingScreenContextUseCase = new LoadLoadingScreenContextUseCase();

            ILoadMetaContextUseCase loadMetaContextUseCase = new LoadMetaContextUseCase();

            ILoadStageUIContextUseCase loadStageUIContextUseCase = new LoadStageUIContextUseCase();

            ILoadStageContextUseCase loadStageContextUseCase = new LoadStageContextUseCase();

            IShowLoadingScreenUseCase showLoadingScreenUseCase = new ShowLoadingScreenUseCase();

            ILoadBaseCheatsUseCase loadBaseCheatsUseCase = new LoadBaseCheatsUseCase();

            ILoadLocalizationDataUseCase loadLocalizationDataUseCase = new LoadLocalizationDataUseCase();

            ILoadStageUseCase loadStageUseCase = new LoadStageUseCase(
                lastLoadedStageSetupState
                );

            IReloadStageUseCase reloadStageUseCase = new ReloadStageUseCase(
                lastLoadedStageSetupState,
                showLoadingScreenUseCase,
                loadStageUseCase
                );

            FlowUseCases flowUseCases = new FlowUseCases(
                loadServicesContextUseCase,
                loadCamerasContextUseCase,
                loadLoadingScreenContextUseCase,
                loadMetaContextUseCase,
                loadStageUIContextUseCase,
                loadStageContextUseCase,
                showLoadingScreenUseCase,
                loadBaseCheatsUseCase,
                loadLocalizationDataUseCase,
                loadStageUseCase,
                reloadStageUseCase
                );

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);
        }
    }
}
