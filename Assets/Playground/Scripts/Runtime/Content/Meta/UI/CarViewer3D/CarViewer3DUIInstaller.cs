using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Configuration.MainMenu;
using Playground.Content.Stage.VisualLogic.Viewer3D;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    [RequireComponent(typeof(CarViewer3DUIView))]
    public class CarViewer3DUIInstaller : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Viewer3DView viewer3DView = default;

        [Header("Configuration")]
        [SerializeField] private CarViewer3DConfiguration carViewer3DConfiguration = default;

        private TickablesService tickablesService;
        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private PersistenceService persistenceService;

        private CarViewFactory carViewFactory;
        private CarViewRepository carViewRepository;

        private CarViewRotationData carViewRotationData;

        private CarViewer3DUIViewModel viewModel;
        private CarViewer3DUIView view;
        private CarViewer3DUIUseCases useCases;
        private CarViewer3DUIController controller;
        private CarViewer3DUIInteractor interactor;

        public CarViewer3DUIInteractor Install()
        {
            GatherDependences();
            GenerateDependences();
            GenerateUseCases();

            OnInstall();

            return interactor;
        }

        public void Uninstall()
        {
            OnUninstall();
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

            viewModel = new CarViewer3DUIViewModel();
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
                viewer3DView,
                configurationService.CarLibrary,
                carViewFactory,
                carViewRepository
                );

            IRotateCarViewUseCase rotateCarViewUseCase = new RotateCarViewUseCase(
                viewer3DView
                );

            IStartManuallyRotatingCarViewUseCase startManuallyRotatingCarViewUseCase = new StartManuallyRotatingCarViewUseCase(
                carViewRotationData
                );

            IStopManuallyRotatingCarViewUseCase stopManuallyRotatingCarViewUseCase = new StopManuallyRotatingCarViewUseCase(
                carViewer3DConfiguration,
                carViewRotationData,
                screenToCanvasDeltaUseCase
                );

            IManuallyRotateCarViewUseCase manuallyRotateCarViewUseCase = new ManuallyRotateCarViewUseCase(
                carViewer3DConfiguration,
                screenToCanvasDeltaUseCase,
                rotateCarViewUseCase
                );

            ICarryCarViewRotationVelocityTickableUseCase carryCarViewRotationVelocityTickableUseCase = new CarryCarViewRotationVelocityTickableUseCase(
                carViewer3DConfiguration,
                carViewRotationData,
                rotateCarViewUseCase
                );

            useCases = new CarViewer3DUIUseCases(
                cleanUpCarViewUseCase,
                showCarViewUseCase,
                rotateCarViewUseCase,
                startManuallyRotatingCarViewUseCase,
                stopManuallyRotatingCarViewUseCase,
                manuallyRotateCarViewUseCase,
                carryCarViewRotationVelocityTickableUseCase
                );
        }

        public void OnInstall()
        {
            view = GetComponent<CarViewer3DUIView>();

            controller = new CarViewer3DUIController(
                viewModel,
                useCases
                );

            interactor = new CarViewer3DUIInteractor(
                useCases
                );

            view.Init(viewModel);

            controller.Subscribe();
            interactor.Subscribe();

            tickablesService.AddTickable(useCases.CarryCarViewRotationVelocityTickableUseCase);
        }

        private void OnUninstall()
        {
            tickablesService.RemoveTickable(useCases.CarryCarViewRotationVelocityTickableUseCase);

            controller.Unsubscribe();
            interactor.Unsubscribe();
        }
    }
}
