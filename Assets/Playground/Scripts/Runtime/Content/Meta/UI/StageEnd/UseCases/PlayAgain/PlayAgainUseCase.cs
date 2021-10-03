using Playground.Services;
using Playground.Services.ViewStack;

namespace Playground.Content.Meta.UI.StageEnd.UseCases.PlayAgain
{
    public class PlayAgainUseCase : IPlayAgainUseCase
    {
        private readonly FlowService flowService;
        private readonly UIViewStackService uiViewStackService;

        public PlayAgainUseCase(
            FlowService flowService,
            UIViewStackService uiViewStackService
            )
        {
            this.flowService = flowService;
            this.uiViewStackService = uiViewStackService;
        }

        public void Execute()
        {
            uiViewStackService.New().Hide<StageEndUIView>(instantly: false).Execute();
            flowService.FlowUseCases.ReloadStageUseCase.Execute().RunAsync();
        }
    }
}
