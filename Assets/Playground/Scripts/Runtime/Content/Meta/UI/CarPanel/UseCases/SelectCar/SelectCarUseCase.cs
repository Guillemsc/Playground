using Playground.Content.Meta.UI.MainMenu;
using Playground.Services;
using Playground.Services.ViewStack;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class SelectCarUseCase : ISelectCarUseCase
    {
        private readonly UIViewStackService uiViewStackService;
        private readonly PersistenceService persistenceService;
        private readonly ViewingCarData viewingCarData;

        public SelectCarUseCase(
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService,
            ViewingCarData viewingCarData
            )
        {
            this.uiViewStackService = uiViewStackService;
            this.persistenceService = persistenceService;
            this.viewingCarData = viewingCarData;
        }

        public void Execute()
        {
            persistenceService.UserDataSerializableData.Data.SelectedCarTypeId = viewingCarData.CarTypeId;

            persistenceService.UserDataSerializableData.Save(default).RunAsync();

            uiViewStackService.New().Show<MainMenuUIView>(instantly: false).Hide<CarPanelUIView>(instantly: true).Execute();
        }
    }
}
