using Playground.Services.ViewStack;

namespace Playground.Content.StageUI.UI.StageSettings.UseCases
{
    public class ClosePanelSelectedUseCase : IClosePanelSelectedUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public ClosePanelSelectedUseCase(UIViewStackService uiViewStackService)
        {
            this.uiViewStackService = uiViewStackService;
        }

        public void Execute()
        {
            uiViewStackService.New().Hide<StageSettingsUIView>(instantly: false).Execute();
        }
    }
}
