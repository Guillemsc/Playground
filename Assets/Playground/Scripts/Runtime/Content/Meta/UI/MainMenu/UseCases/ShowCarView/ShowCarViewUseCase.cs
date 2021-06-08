using Playground.Configuration.Car;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.Viewer3D;
using Playground.Libraries.Car;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class ShowCarViewUseCase : IShowCarViewUseCase
    {
        private readonly Viewer3DView carViewer3DView;
        private readonly CarLibrary carLibrary;
        private readonly CarViewRepository carViewRepository;

        public ShowCarViewUseCase(
            Viewer3DView carViewer3DView,
            CarLibrary carLibrary,
            CarViewRepository carViewRepository
            )
        {
            this.carViewer3DView = carViewer3DView;
            this.carLibrary = carLibrary;
            this.carViewRepository = carViewRepository;
        }

        public void Execute()
        {
            CarConfiguration carConfiguration = carLibrary.Items[0];

            CarView carViewInstance = carConfiguration.CarViewPrefab.InstantiateGameObjectAndGetComponent();
            carViewInstance.DisablePhysics();
            carViewInstance.SetSteering(20);

            carViewRepository.Set(carViewInstance);

            carViewer3DView.Show(carViewInstance.gameObject);
            carViewer3DView.Pivot.localRotation = Quaternion.Euler(0, 135.0f, 0);
        }
    }
}
