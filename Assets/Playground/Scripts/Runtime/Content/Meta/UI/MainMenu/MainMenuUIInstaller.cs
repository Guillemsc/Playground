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
        }

        private void GenerateDependences()
        {
            carViewRepository = new CarViewRepository();

            viewModel = new MainMenuUIViewModel();
        }

        private void GenerateUseCases()
        {
            IShowCarViewUseCase show3DCarUseCase = new ShowCarViewUseCase(
                carViewer3DView,
                configurationService.CarLibrary,
                carViewRepository
                );

            IManuallyRotateCarViewUseCase manuallyRotate3DCarUseCase = new ManuallyRotateCarViewUseCase(
                carViewer3DView,
                uiViewStackService.Canvas
                );

            useCases = new MainMenuUIUseCases(
                show3DCarUseCase,
                manuallyRotate3DCarUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<MainMenuUIView>();

            controller = new MainMenuUIController(viewModel, useCases);
            interactor = new MainMenuUIInteractor(viewModel, useCases);

            view.Init(viewModel, useCases);

            controller.Subscribe();
            interactor.Subscribe();

            uiViewStackService.Register(interactor, view);
        }

        private void Uninstall()
        {
            controller.Unsubscribe();
            interactor.Unsubscribe();

            uiViewStackService.Unregister(interactor, view);
        }
    }
}
