using Juce.Core.Disposables;
using Playground.Configuration.Car;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.Viewer3D;
using Playground.Libraries.Car;
using Playground.Services;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class ShowCarViewUseCase : IShowCarViewUseCase
    {
        private readonly UserService userService;
        private readonly Viewer3DView carViewer3DView;
        private readonly CarLibrary carLibrary;
        private readonly CarViewFactory carViewFactory;
        private readonly CarViewRepository carViewRepository;

        public ShowCarViewUseCase(
            UserService userService,
            Viewer3DView carViewer3DView,
            CarLibrary carLibrary,
            CarViewFactory carViewFactory,
            CarViewRepository carViewRepository
            )
        {
            this.userService = userService;
            this.carViewer3DView = carViewer3DView;
            this.carLibrary = carLibrary;
            this.carViewFactory = carViewFactory;
            this.carViewRepository = carViewRepository;
        }

        public void Execute()
        {
            bool found = carLibrary.TryGet(userService.UserData.SelectedCarTypeId, out CarConfiguration carConfiguration);

            if(!found)
            {
                carConfiguration = carLibrary.Items[0];
                userService.UserData.SelectedCarTypeId = carConfiguration.CarTypeId;
            }

            IDisposable<CarView> instance = carViewFactory.Create(carConfiguration);

            carViewRepository.Set(instance);

            carViewer3DView.Show(instance.Value.gameObject);
            carViewer3DView.Pivot.localRotation = Quaternion.Euler(0, 135.0f, 0);
        }
    }
}
