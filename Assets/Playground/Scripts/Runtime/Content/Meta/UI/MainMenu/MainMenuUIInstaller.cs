using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Configuration.MainMenu;
using Playground.Content.Stage.VisualLogic.Viewer3D;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    [RequireComponent(typeof(MainMenuUIView))]
    public class MainMenuUIInstaller : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Viewer3DView carViewer3DView = default;

        [Header("Configuration")]
        [SerializeField] private MainMenuConfiguration mainMenuConfiguration = default;

        private TickablesService tickablesService;
        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private PersistenceService persistenceService;

        private CarViewFactory carViewFactory;
        private CarViewRepository carViewRepository;

        private CarViewRotationData carViewRotationData;

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
            tickablesService = ServicesProvider.GetService<TickablesService>();
            uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            configurationService = ServicesProvider.GetService<ConfigurationService>();
            persistenceService = ServicesProvider.GetService<PersistenceService>();
        }

        private void GenerateDependences()
        {
            carViewFactory = new CarViewFactory();
            carViewRepository = new CarViewRepository();

            carViewRotationData = new CarViewRotationData();

            viewModel = new MainMenuUIViewModel();
        }

        private void GenerateUseCases()
        {
            IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase = new ScreenToCanvasDeltaUseCase(
                uiViewStackService.Canvas
                );

            ICleanUpCarViewUseCase cleanUpCarViewUseCase = new CleanUpCarViewUseCase(
                carViewRepository
                );

            IShowCarViewUseCase showCarViewUseCase = new ShowCarViewUseCase(
                persistenceService,
                carViewer3DView,
                configurationService.CarLibrary,
                carViewFactory,
                carViewRepository
                );

            IRotateCarViewUseCase rotateCarViewUseCase = new RotateCarViewUseCase(
                carViewer3DView
                );

            IStartManuallyRotatingCarViewUseCase startManuallyRotatingCarViewUseCase = new StartManuallyRotatingCarViewUseCase(
                carViewRotationData
                );

            IStopManuallyRotatingCarViewUseCase stopManuallyRotatingCarViewUseCase = new StopManuallyRotatingCarViewUseCase(
                mainMenuConfiguration,
                carViewRotationData,
                screenToCanvasDeltaUseCase
                );

            IManuallyRotateCarViewUseCase manuallyRotateCarViewUseCase = new ManuallyRotateCarViewUseCase(
                mainMenuConfiguration,
                carViewRotationData,
                screenToCanvasDeltaUseCase,
                rotateCarViewUseCase
                );

            ICarryCarViewRotationVelocityTickableUseCase carryCarViewRotationVelocityTickableUseCase = new CarryCarViewRotationVelocityTickableUseCase(
                mainMenuConfiguration,
                carViewRotationData,
                rotateCarViewUseCase
                );

            IRefreshStarsUseCase setStarsUseCase = new RefreshStarsUseCase(
                viewModel,
                persistenceService
                );

            IRefreshSoftCurrencyUseCase refreshSoftCurrencyUseCase = new RefreshSoftCurrencyUseCase(
                viewModel,
                persistenceService
                );

            useCases = new MainMenuUIUseCases(
                screenToCanvasDeltaUseCase,
                cleanUpCarViewUseCase,
                showCarViewUseCase,
                rotateCarViewUseCase,
                startManuallyRotatingCarViewUseCase,
                stopManuallyRotatingCarViewUseCase,
                manuallyRotateCarViewUseCase,
                carryCarViewRotationVelocityTickableUseCase,
                setStarsUseCase,
                refreshSoftCurrencyUseCase
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

            tickablesService.AddTickable(useCases.CarryCarViewRotationVelocityTickableUseCase);
        }

        private void Uninstall()
        {
            tickablesService.RemoveTickable(useCases.CarryCarViewRotationVelocityTickableUseCase);

            controller.Unsubscribe();
            interactor.Unsubscribe();

            uiViewStackService.Unregister(view);
        }
    }
}
