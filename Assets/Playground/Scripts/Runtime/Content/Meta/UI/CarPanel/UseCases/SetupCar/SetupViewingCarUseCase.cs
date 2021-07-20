using Playground.Configuration.Car;
using Playground.Libraries.Car;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class SetupViewingCarUseCase : ISetupViewingCarUseCase
    {
        private readonly CarLibrary carLibrary;
        private readonly ViewingCarData viewingCarData;
        private readonly CarPanelUIViewModel carPanelUIViewModel;

        public SetupViewingCarUseCase(
            CarLibrary carLibrary,
            ViewingCarData viewingCarData,
            CarPanelUIViewModel carPanelUIViewModel
            )
        {
            this.carLibrary = carLibrary;
            this.viewingCarData = viewingCarData;
            this.carPanelUIViewModel = carPanelUIViewModel;
        }

        public void Execute(string carTypeId)
        {
            bool found = carLibrary.TryGet(carTypeId, out CarConfiguration carConfiguration);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Car with id {carTypeId} could not be found at" +
                    $"{nameof(CarLibrary)}. Using default car at {nameof(SetupViewingCarUseCase)}");

                carConfiguration = carLibrary.Items[0];
            }

            viewingCarData.CarTypeId = carConfiguration.CarTypeId;

            carPanelUIViewModel.CarNameVariable.Value = carConfiguration.CarName;
            carPanelUIViewModel.CarDescriptionVariable.Value = carConfiguration.CarDescription;
        }
    }
}
