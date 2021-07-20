using Playground.Configuration.Car;
using Playground.Content.Meta.UI.CarViewer3D;
using Playground.Libraries.Car;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class RefreshCarUseCase : IRefreshCarUseCase
    {
        private readonly CarViewer3DUIInteractor carViewer3DInteractor;
        private readonly CarLibrary carLibrary;
        private readonly ViewingCarData viewingCarData;

        public RefreshCarUseCase(
            CarViewer3DUIInteractor carViewer3DInteractor,
            CarLibrary carLibrary,
            ViewingCarData viewingCarData
            )
        {
            this.carViewer3DInteractor = carViewer3DInteractor;
            this.carLibrary = carLibrary;
            this.viewingCarData = viewingCarData;
        }

        public void Execute()
        {
            bool found = carLibrary.TryGet(viewingCarData.CarTypeId, out CarConfiguration carConfiguration);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Car with id {viewingCarData.CarTypeId} could not be found at" +
                    $"{nameof(CarLibrary)}. Using default car at {nameof(RefreshCarUseCase)}");

                carConfiguration = carLibrary.Items[0];
            }

            carViewer3DInteractor.ShowCar(carConfiguration.CarTypeId);
        }
    }
}
