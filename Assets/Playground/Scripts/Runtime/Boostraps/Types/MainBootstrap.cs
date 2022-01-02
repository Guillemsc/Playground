using System.Threading.Tasks;
using UnityEngine;
using Playground.Configuration.Stage;
using Juce.Core.DI.Builder;
using Playground.Installers;
using Juce.Core.DI.Container;
using Playground.Contexts.LoadingScreen;
using Juce.Core.Loading;
using Playground.Contexts.Cameras;
using Playground.Services.Persistence;
using System.Threading;
using Playground.Services.Configuration;
using Assets.Playground.Scripts.Runtime.Cheats.Base;
using Playground.Contexts.Meta;
using Playground.Contexts.Stage;
using Playground.Contexts.StageUI;
using Playground.Content.Stage.Setup;

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
            IDIContainerBuilder servicesContainerBuilder = new DIContainerBuilder();

            servicesContainerBuilder.InstallServices(
                gameObject,
                defaultStageConfiguration
                );

            IDIContainer servicesContainer = servicesContainerBuilder.Build();

            IPersistenceService persistenceService = servicesContainer.Resolve<IPersistenceService>();
            ICheatsService cheatsService = servicesContainer.Resolve<ICheatsService>();

            var camerasContextResult = await new CamerasContextFactory().TryCreate();

            var loadingScreenContextResult = await new LoadingScreenContextFactory().TryCreate();

            ILoadingToken loadingToken = await loadingScreenContextResult.Value.Value.Show();

            cheatsService.Add(BaseCheatsInstaller.Install(servicesContainer));

            await persistenceService.LoadAll(CancellationToken.None);

            var metaContextResult = await new MetaContextFactory().TryCreate();

            var stageUIContextResult = await new StageUIContextFactory().TryCreate();

            var stageContextResult = await new StageContextFactory(
                servicesContainer,
                stageUIContextResult.Value.Value.Container
                ).TryCreate();

            StageSetup stageSetup = defaultStageConfiguration.ToSetup();

            await stageContextResult.Value.Value.LoadStage(
                stageSetup,
                null
                );

            //ILoadingScreenContext loadingScreenContext = await LoadLoadingScreenContextUseCase.Instance.Execute();

            //await loadingScreenContext.SetVisible(visible: true);

            //ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenUseCase.Execute();

            //await flowUseCases.LoadPersistanceUseCase.Execute();
            //await flowUseCases.LoadCamerasContextUseCase.Execute();

            //flowUseCases.LoadBaseCheatsUseCase.Execute();

            //await flowUseCases.LoadLocalizationDataUseCase.Execute();

            //await flowUseCases.LoadMetaContextUseCase.Execute();
            //await flowUseCases.LoadStageUIContextUseCase.Execute();
            //await flowUseCases.LoadStageContextUseCase.Execute();

            //StageSetup stageSetup = defaultStageConfiguration.ToSetup();

            //await flowUseCases.LoadStageUseCase.Execute(stageSetup);

            //loadingToken.Complete();

            //await flowUseCases.LoadUserDataFlowUseCase.Execute();

            //await flowUseCases.LoadAdsScenesFlowUseCase.Execute();
        }

        private void GenerateFlowService()
        {
            //LastLoadedStageSetupState lastLoadedStageSetupState = new LastLoadedStageSetupState();

            //ILoadMetaContextUseCase loadMetaContextUseCase = new LoadMetaContextUseCase();

            //ILoadStageUIContextUseCase loadStageUIContextUseCase = new LoadStageUIContextUseCase();

            //ILoadStageContextUseCase loadStageContextUseCase = new LoadStageContextUseCase();

            //ILoadPersistanceUseCase loadPersistanceUseCase = new LoadPersistanceUseCase();

            //IShowLoadingScreenUseCase showLoadingScreenUseCase = new ShowLoadingScreenUseCase();

            //ILoadBaseCheatsUseCase loadBaseCheatsUseCase = new LoadBaseCheatsUseCase();

            //ILoadLocalizationDataUseCase loadLocalizationDataUseCase = new LoadLocalizationDataUseCase();

            //ILoadStageUseCase loadStageUseCase = new LoadStageUseCase(
            //    lastLoadedStageSetupState
            //    );

            //IReloadStageUseCase reloadStageUseCase = new ReloadStageUseCase(
            //    lastLoadedStageSetupState,
            //    showLoadingScreenUseCase,
            //    loadStageUseCase
            //    );

            //FlowUseCases flowUseCases = new FlowUseCases(
            //    loadMetaContextUseCase,
            //    loadStageUIContextUseCase,
            //    loadStageContextUseCase,
            //    loadPersistanceUseCase,
            //    showLoadingScreenUseCase,
            //    loadBaseCheatsUseCase,
            //    loadLocalizationDataUseCase,
            //    loadStageUseCase,
            //    reloadStageUseCase
            //    );

            //FlowService flowService = new FlowService(flowUseCases);
            //ServicesProvider.Register(flowService);
        }
    }
}
