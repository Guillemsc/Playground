using Playground.Content.StageUI.UI.StageSettings;
using Playground.Services.ViewStack;

namespace Playground.Content.StageUI.UI.StageOverlay.UseCases
{
    public class SettingsSelectedUseCase : ISettingsSelectedUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public SettingsSelectedUseCase(UIViewStackService uiViewStackService)
        {
            this.uiViewStackService = uiViewStackService;
        }

        public void Execute()
        {
            uiViewStackService.New().Show<StageSettingsUIView>(instantly: false).Execute();
        }
    }
}
