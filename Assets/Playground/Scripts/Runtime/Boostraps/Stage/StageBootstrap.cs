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

            await flowUseCases.LoadLocalizationDataFlowUseCase.Execute();

            flowUseCases.SetCurrentStageFlowUseCase.Execute(stageConfiguration);

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: true);

            await flowUseCases.PlayScenarioFlowUseCase.Execute(loadingToken);
        }

        private void GenerateFlowService()
        {
            CurrentStageFlowData currentStageFlowData = new CurrentStageFlowData();

            FlowUseCases flowUseCases = new FlowUseCases(
                new LoadEssentialScenesFlowUseCase(),
                new LoadLocalizationDataFlowUseCase(),
                new ShowLoadingScreenFlowUseCase(),
                new NopLoadUserDataFlowUseCase(),
                new NopLoadAdsScenesFlowUseCase(),
                new NopLoadMetaFlowUseCase(),
                new NopUnloadMetaFlowUseCase(),
                new SetCurrentStageFlowUseCase(currentStageFlowData),
                new StageBootstrapPlayScenarioFlowUseCase(currentStageFlowData, carTypeId),
                new StageBootstrapReplayScenarioFlowUseCase(currentStageFlowData),
                new NopBackToMetaFromStageFlowUseCase()
                );

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);
        }

        private void GenerateSharedService()
        {
            ISaveProgressUseCase saveProgressUseCase = new NopSaveProgressUseCase();
            IGetOwnedCarsUseCase getOwnedCarsUseCase = new NopGetOwnedCarsUseCase();
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase = new NopGetStageStarsFromTimingUseCase();
            ITryGetStageCarStarsUseCase tryGetStageCarStarsUseCase = new NopTryGetStageCarStarsUseCase();
            ISetStageCarStarsUseCase setStageCarStarsUseCase = new NopSetStageCarStarsUseCase();
            IAddSoftCurrencyUseCase addSoftCurrencyUseCase = new NopAddSoftCurrencyUseCase();
            IRemoveSoftCurrencyUseCase removeSoftCurrencyUseCase = new NopRemoveSoftCurrencyUseCase();

            SharedUseCases sharedUseCases = new SharedUseCases(
                saveProgressUseCase,
                getOwnedCarsUseCase,
                getStageStarsFromTimingUseCase,
                tryGetStageCarStarsUseCase,
                setStageCarStarsUseCase,
                addSoftCurrencyUseCase,
                removeSoftCurrencyUseCase
                );

            SharedService sharedService = new SharedService(sharedUseCases);
            ServicesProvider.Register(sharedService);
        }
    }
}
