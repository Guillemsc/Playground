using Juce.CoreUnity.Service;
using Juce.TweenPlayer;
using Playground.Content.Meta.UI.CarViewer3D;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarPanel
{
    [RequireComponent(typeof(CarPanelUIView))]
    public class CarPanelUIInstaller : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CarViewer3DUIInstaller carViewer3DInstaller = default;
        [SerializeField] private TweenPlayer showPurchasedFeedback = default;
        [SerializeField] private TweenPlayer showNonPurchasedFeedback = default;

        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private PersistenceService persistenceService;
        private SharedService sharedService;

        private CarViewer3DUIInteractor carViewer3DInteractor;

        private ViewingCarData viewingCarData;

        private CarPanelUIViewModel viewModel;
        private CarPanelUIView view;
        private CarPanelUIUseCases useCases;
        private CarPanelUIController controller;
        private CarPanelUIInteractor interactor;

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
            persistenceService = ServicesProvider.GetService<PersistenceService>();
            sharedService = ServicesProvider.GetService<SharedService>();
        }

        private void GenerateDependences()
        {
            carViewer3DInteractor = carViewer3DInstaller.Install();

            viewingCarData = new ViewingCarData();

            viewModel = new CarPanelUIViewModel();
        }

        private void GenerateUseCases()
        {
            ISetupViewingCarUseCase setupViewingCarUseCase = new SetupViewingCarUseCase(
                sharedService,
                configurationService.CarLibrary,
                viewingCarData,
                viewModel,
                showPurchasedFeedback,
                showNonPurchasedFeedback
                );

            IRefreshCarUseCase refreshCarUseCase = new RefreshCarUseCase(
                carViewer3DInteractor,
                configurationService.CarLibrary,
                viewingCarData
                );

            ISelectCarUseCase selectCarUseCase = new SelectCarUseCase(
                uiViewStackService,
                persistenceService,
                viewingCarData
                );

            IPurchaseCaseUseCase purchaseCarUseCase = new PurchaseCarUseCase(
                uiViewStackService,
                viewingCarData
                );

            useCases = new CarPanelUIUseCases(
                setupViewingCarUseCase,
                refreshCarUseCase,
                selectCarUseCase,
                purchaseCarUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<CarPanelUIView>();

            controller = new CarPanelUIController(viewModel, useCases);
            interactor = new CarPanelUIInteractor(viewModel, useCases);

            view.Init(viewModel);

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
