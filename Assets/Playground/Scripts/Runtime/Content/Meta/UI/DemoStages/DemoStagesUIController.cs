using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Configuration;
using Playground.Services;
using System.Threading.Tasks;

namespace Playground.Content.Meta.UI.DemoStages
{
    public class DemoStagesUIController
    {
        private readonly DemoStagesUIViewModel viewModel;
        private readonly DemoStagesUIUseCases useCases;

        public DemoStagesUIController(
            DemoStagesUIViewModel viewModel,
            DemoStagesUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnDemoStageButtonClickedEvent.OnExecute += OnDemoStageButtonClicked;

            useCases.SpawnDemoStagesUseCase.Execute();
        }

        public void Unsubscribe()
        {
            viewModel.OnDemoStageButtonClickedEvent.Clear();
        }

        private void OnDemoStageButtonClicked(DemoStageButtonUIEntry demoStageButtonUIEntry, PointerCallbacks pointerCallbacks)
        {
            PlayStage(demoStageButtonUIEntry.StageConfiguration).RunAsync();
        }

        private async Task PlayStage(StageConfiguration stageConfiguration)
        {
            FlowService flowService = ServicesProvider.GetService<FlowService>();

            ILoadingToken loadingToken = await flowService.FlowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: false);

            flowService.FlowUseCases.SetCurrentStageFlowUseCase.Execute(stageConfiguration);

            await flowService.FlowUseCases.UnloadMetaFlowUseCase.Execute();

            await flowService.FlowUseCases.PlayScenarioFlowUseCase.Execute(loadingToken);
        }
    }
} 
