using System.Threading.Tasks;
using UnityEngine;
using Playground.Flow.UseCases;
using Playground.Services;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Flow.Data;
using Playground.Configuration.Stage;
using Playground.Shared.UseCases;

namespace Playground.Boostraps
{
    public class StageBootstrap : MonoBehaviour
    {
        [SerializeField] private StageConfiguration stageConfiguration = default;
        [SerializeField] private string carTypeId = default;

        private void Awake()
        {
            Run().RunAsync();
        }

        private async Task Run()
        {
            if(stageConfiguration.StageSceneReference == null)
            {
                UnityEngine.Debug.LogError($"Stage scene is not referenced, at {nameof(StageBootstrap)}");
                return;
            }

            GenerateFlowService();
            GenerateSharedService();

            FlowService flowService = ServicesProvider.GetService<FlowService>();
            FlowUseCases flowUseCases = flowService.FlowUseCases;

            await flowUseCases.LoadEssentialScenesFlowUseCase.Execute();

            flowUseCases.LoadBaseCheatsFlowUseCase.Execute();

            await flowUseCases.LoadLocalizationDataFlowUseCase.Execute();

            flowUseCases.SetCurrentStageFlowUseCase.Execute(stageConfiguration);

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: true);

            await flowUseCases.PlayScenarioFlowUseCase.Execute(loadingToken);
        }

        private void GenerateFlowService()
        {
            CurrentStageFlowData currentStageFlowData = new CurrentStageFlowData();

            ILoadEssentialScenesFlowUseCase loadEssentialScenesFlowUseCase = new LoadEssentialScenesFlowUseCase();
            ILoadBaseCheatsFlowUseCase loadBaseCheatsFlowUseCase = new LoadBaseCheatsFlowUseCase();
            ILoadLocalizationDataFlowUseCase loadLocalizationDataFlowUseCase = new LoadLocalizationDataFlowUseCase();
            IShowLoadingScreenFlowUseCase showLoadingScreenFlowUseCase = new ShowLoadingScreenFlowUseCase();
            ILoadUserDataFlowUseCase loadUserDataFlowUseCase = new NopLoadUserDataFlowUseCase();
            ILoadAdsScenesFlowUseCase loadAdsScenesFlowUseCase = new NopLoadAdsScenesFlowUseCase();
            ILoadMetaFlowUseCase loadMetaFlowUseCase = new NopLoadMetaFlowUseCase();
            IUnloadMetaFlowUseCase unloadMetaFlowUseCase = new NopUnloadMetaFlowUseCase();
            ISetCurrentStageFlowUseCase setCurrentStageFlowUseCase = new SetCurrentStageFlowUseCase(currentStageFlowData);
            IPlayScenarioFlowUseCase playScenarioFlowUseCase = new StageBootstrapPlayScenarioFlowUseCase(currentStageFlowData, carTypeId);
            IReplayScenarioFlowUseCase replayScenarioFlowUseCase = new StageBootstrapReplayScenarioFlowUseCase(currentStageFlowData);
            IBackToMetaFromStageFlowUseCase backToMetaFromStageFlowUseCase = new NopBackToMetaFromStageFlowUseCase();
            ISetStageCheatsActiveFlowUseCase setStageCheatsActiveFlowUseCase = new SetStageCheatsActiveFlowUseCase();

            FlowUseCases flowUseCases = new FlowUseCases(
                loadEssentialScenesFlowUseCase,
                loadBaseCheatsFlowUseCase,
                setStageCheatsActiveFlowUseCase,
                loadLocalizationDataFlowUseCase,
                showLoadingScreenFlowUseCase,
                loadUserDataFlowUseCase,
                loadAdsScenesFlowUseCase,
                loadMetaFlowUseCase,
                unloadMetaFlowUseCase,
                setCurrentStageFlowUseCase,
                playScenarioFlowUseCase,
                replayScenarioFlowUseCase,
                backToMetaFromStageFlowUseCase
                );

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);
        }

        private void GenerateSharedService()
        {
            ISaveProgressUseCase saveProgressUseCase = new NopSaveProgressUseCase();
            IGetOwnedCarsUseCase getOwnedCarsUseCase = new NopGetOwnedCarsUseCase();
            IIsCarOwnedUseCase isCarOwnedUseCase = new NopIsCarOwnedUseCase();
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase = new NopGetStageStarsFromTimingUseCase();
            ITryGetStageCarStarsUseCase tryGetStageCarStarsUseCase = new NopTryGetStageCarStarsUseCase();
            ISetStageCarStarsUseCase setStageCarStarsUseCase = new NopSetStageCarStarsUseCase();
            IAddSoftCurrencyUseCase addSoftCurrencyUseCase = new NopAddSoftCurrencyUseCase();
            IRemoveSoftCurrencyUseCase removeSoftCurrencyUseCase = new NopRemoveSoftCurrencyUseCase();
            IHasEnoughSoftCurrencyUseCase hasEnoughSoftCurrencyUseCase = new NopHasEnoughSoftCurrencyUseCase();
            IPurchaseCarUseCase purchaseCarUseCase = new NopPurchaseCarUseCase();

            SharedUseCases sharedUseCases = new SharedUseCases(
                saveProgressUseCase,
                getOwnedCarsUseCase,
                isCarOwnedUseCase,
                getStageStarsFromTimingUseCase,
                tryGetStageCarStarsUseCase,
                setStageCarStarsUseCase,
                addSoftCurrencyUseCase,
                removeSoftCurrencyUseCase,
                hasEnoughSoftCurrencyUseCase,
                purchaseCarUseCase
                );

            SharedService sharedService = new SharedService(sharedUseCases);
            ServicesProvider.Register(sharedService);
        }
    }
}
