using Playground.Content.Meta.UI.CarPanel;
using Playground.Services.ViewStack;

namespace Playground.Content.Meta.UI.Shop
{
    public class CarSelectedUseCase : ICarSelectedUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public CarSelectedUseCase(UIViewStackService uiViewStackService)
        {
            this.uiViewStackService = uiViewStackService;
        }

        public void Execute(string carTypeId)
        {
            CarPanelUIInteractor carPanelUIInteractor = uiViewStackService.GetInteractor<CarPanelUIInteractor>();

            carPanelUIInteractor.SetupViewingCar(carTypeId);

            uiViewStackService.New().Show<CarPanelUIView>(instantly: false).Hide<ShopUIView>(instantly: true).Execute();
        }
    }
}
