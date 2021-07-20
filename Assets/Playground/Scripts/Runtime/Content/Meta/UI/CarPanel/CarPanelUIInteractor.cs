using Juce.CoreUnity.UI;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIInteractor : UIInteractor
    {
        private readonly CarPanelUIViewModel viewModel;
        private readonly CarPanelUIUseCases useCases;

        public CarPanelUIInteractor(
            CarPanelUIViewModel viewModel,
            CarPanelUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Refresh()
        {
            useCases.RefreshCarUseCase.Execute();
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }

        public void SetupViewingCar(string carTypeId)
        {
            useCases.SetupViewingCarUseCase.Execute(carTypeId);
        }
    }
}
