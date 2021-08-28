using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Services;
using Playground.Services.ViewStack;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class PlayAgainUseCase : IPlayAgainUseCase
    {
        private readonly StageCompletedUIViewModel stageCompletedUIViewModel;

        public PlayAgainUseCase(StageCompletedUIViewModel stageCompletedUIViewModel)
        {
            this.stageCompletedUIViewModel = stageCompletedUIViewModel;
        }

        public async void Execute()
        {
            //UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();

            //await uiViewStackService.New().Hide<StageCompletedUIView>(instantly: false).Execute(default);

            //FlowService flowService = ServicesProvider.GetService<FlowService>();

            //ILoadingToken loadingToken = await flowService.FlowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: false);

            //stageCompletedUIViewModel.CanUnloadStageCommand.Execute();

            //await flowService.FlowUseCases.ReplayScenarioFlowUseCase.Execute(loadingToken);
        }
    }
}
