using System.Threading.Tasks;
using UnityEngine;
using Playground.Flow.UseCases;
using Playground.Services;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Flow.Data;
using Playground.Shared.UseCases;

namespace Playground.Boostraps
{
    public class MainBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Run().RunAsync();
        }

        private async Task Run()
        {
            GenerateFlowService();
            GenerateSharedService();

            FlowService flowService = ServicesProvider.GetService<FlowService>();
            FlowUseCases flowUseCases = flowService.FlowUseCases;

            await flowUseCases.LoadEssentialScenesFlowUseCase.Execute();

            flowUseCases.LoadBaseCheatsFlowUseCase.Execute();

            await flowUseCases.LoadLocalizationDataFlowUseCase.Execute();

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: true);

            await flowUseCases.LoadUserDataFlowUseCase.Execute();

            await flowUseCases.LoadAdsScenesFlowUseCase.Execute();

            await flowUseCases.LoadMetaFlowUseCase.Execute(loadingToken);
        }

        private void GenerateFlowService()
        {
            CurrentStageFlowData currentStageFlowData = new CurrentStageFlowData();

            FlowUseCases flowUseCases = new FlowUseCases(
                new LoadEssentialScenesFlowUseCase(),
                new LoadBaseCheatsFlowUseCase(),
                new LoadLocalizationDataFlowUseCase(),
                new ShowLoadingScreenFlowUseCase(),
                new LoadUserDataFlowUseCase(),
                new LoadAdsScenesFlowUseCase(),
                new LoadMetaFlowUseCase(),
                new UnloadMetaFlowUseCase(),
                new SetCurrentStageFlowUseCase(currentStageFlowData),
                new MainBootstrapPlayScenarioFlowUseCase(currentStageFlowData),
                new StageBootstrapReplayScenarioFlowUseCase(currentStageFlowData),
                new BackToMetaFromStageFlowUseCase(currentStageFlowData)
                );

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);
        }

        private void GenerateSharedService()
        {
            ISaveProgressUseCase saveProgressUseCase = new SaveProgressUseCase();
            IGetOwnedCarsUseCase getOwnedCarsUseCase = new GetOwnedCarsUseCase();
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase = new GetStageStarsFromTimingUseCase();
            ITryGetStageCarStarsUseCase tryGetStageCarStarsUseCase = new TryGetStageCarStarsUseCase();
            ISetStageCarStarsUseCase setStageCarStarsUseCase = new SetStageCarStarsUseCase();
            IAddSoftCurrencyUseCase addSoftCurrencyUseCase = new AddSoftCurrencyUseCase();
            IRemoveSoftCurrencyUseCase removeSoftCurrencyUseCase = new RemoveSoftCurrencyUseCase();

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
