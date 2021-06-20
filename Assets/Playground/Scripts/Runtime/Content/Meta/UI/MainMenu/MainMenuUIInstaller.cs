using Juce.CoreUnity.Service;
using Playground.Content.Stage.VisualLogic.Viewer3D;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    [RequireComponent(typeof(MainMenuUIView))]
    public class MainMenuUIInstaller : MonoBehaviour
    {
        [SerializeField] private Viewer3DView carViewer3DView = default;

        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private UserService userService;

        private CarViewFactory carViewFactory;
        private CarViewRepository carViewRepository;

        private MainMenuUIViewModel viewModel;
        private MainMenuUIView view;
        private MainMenuUIUseCases useCases;
        private MainMenuUIController controller;
        private MainMenuUIInteractor interactor;

        private void Start()
        {
            GatherDependences();
            GenerateDependences();
            GenerateUseCases();

            Install();
        }

        private void OnDestroy()
        {
            Uninstall();
        }

        private void GatherDependences()
        {
            uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            configurationService = ServicesProvider.GetService<ConfigurationService>();
            userService = ServicesProvider.GetService<UserService>();
        }

        private void GenerateDependences()
        {
            carViewFactory = new CarViewFactory();
            carViewRepository = new CarViewRepository();

            viewModel = new MainMenuUIViewModel();
        }

        private void GenerateUseCases()
        {
            ICleanUpCarViewUseCase cleanUpCarViewUseCase = new CleanUpCarViewUseCase(
                carViewRepository
                );

            IShowCarViewUseCase show3DCarUseCase = new ShowCarViewUseCase(
                userService,
                carViewer3DView,
                configurationService.CarLibrary,
                carViewFactory,
                carViewRepository
                );

            IManuallyRotateCarViewUseCase manuallyRotate3DCarUseCase = new ManuallyRotateCarViewUseCase(
                carViewer3DView,
                uiViewStackService.Canvas
                );

            useCases = new MainMenuUIUseCases(
                cleanUpCarViewUseCase,
                show3DCarUseCase,
                manuallyRotate3DCarUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<MainMenuUIView>();

            controller = new MainMenuUIController(
                viewModel, 
                useCases, 
                uiViewStackService
                );

            interactor = new MainMenuUIInteractor(
                viewModel, 
                useCases
                );

            view.Init(viewModel, useCases);

            controller.Subscribe();
            interactor.Subscribe();

            uiViewStackService.Register(interactor, view);
        }

        private void Uninstall()
        {
            controller.Unsubscribe();
            interactor.Unsubscribe();

            uiViewStackService.Unregister(view);
        }
    }
}
