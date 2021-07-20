using Playground.Configuration.Car;
using Playground.Content.Meta.UI.CarViewer3D;
using Playground.Libraries.Car;
using Playground.Services;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class RefreshCarUseCase : IRefreshCarUseCase
    {
        private readonly PersistenceService persistenceService;
        private readonly CarViewer3DUIInteractor carViewer3DInteractor;
        private readonly CarLibrary carLibrary;

        public RefreshCarUseCase(
            PersistenceService persistenceService,
            CarViewer3DUIInteractor carViewer3DInteractor,
            CarLibrary carLibrary
            )
        {
            this.persistenceService = persistenceService;
            this.carViewer3DInteractor = carViewer3DInteractor;
            this.carLibrary = carLibrary;
        }

        public void Execute()
        {
            string userDataSelectedCarTypeId = persistenceService.UserDataSerializableData.Data.SelectedCarTypeId;

            bool found = carLibrary.TryGet(userDataSelectedCarTypeId, out CarConfiguration carConfiguration);

            if (!found)
            {
                carConfiguration = carLibrary.Items[0];
                persistenceService.UserDataSerializableData.Data.SelectedCarTypeId = carConfiguration.CarTypeId;
            }

            carViewer3DInteractor.ShowCar(carConfiguration.CarTypeId);
        }
    }
}
