using Juce.Core.Disposables;
using Playground.Configuration.Car;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.Viewer3D;
using Playground.Libraries.Car;
using Playground.Services;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class ShowCarViewUseCase : IShowCarViewUseCase
    {
        private readonly PersistenceService persistenceService;
        private readonly Viewer3DView carViewer3DView;
        private readonly CarLibrary carLibrary;
        private readonly CarViewFactory carViewFactory;
        private readonly CarViewRepository carViewRepository;

        public ShowCarViewUseCase(
            PersistenceService persistenceService,
            Viewer3DView carViewer3DView,
            CarLibrary carLibrary,
            CarViewFactory carViewFactory,
            CarViewRepository carViewRepository
            )
        {
            this.persistenceService = persistenceService;
            this.carViewer3DView = carViewer3DView;
            this.carLibrary = carLibrary;
            this.carViewFactory = carViewFactory;
            this.carViewRepository = carViewRepository;
        }

        public void Execute(string carTypeId)
        {
            bool found = carLibrary.TryGet(carTypeId, out CarConfiguration carConfiguration);

            if(!found)
            {
                UnityEngine.Debug.LogError($"Car with id {carTypeId} could not be found. " +
                    $"Using default, at {nameof(ShowCarViewUseCase)}");

                carConfiguration = carLibrary.Items[0];
            }

            IDisposable<CarView> instance = carViewFactory.Create(carConfiguration);

            carViewRepository.Set(instance);

            carViewer3DView.Show(instance.Value.gameObject);
            carViewer3DView.Pivot.localRotation = Quaternion.Euler(0, 135.0f, 0);
        }
    }
}
