using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Configuration.MainMenu;
using Playground.Content.Meta.UI.CarViewer3D;
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
        [SerializeField] private CarViewer3DUIInstaller carViewer3DInstaller = default;

        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private PersistenceService persistenceService;

        private CarViewer3DUIInteractor carViewer3DInteractor;

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
            persistenceService = ServicesProvider.GetService<PersistenceService>();
        }

        private void GenerateDependences()
        {
            carViewer3DInteractor = carViewer3DInstaller.Install();

            viewModel = new MainMenuUIViewModel();
        }

        private void GenerateUseCases()
        {
            IRefreshStarsUseCase setStarsUseCase = new RefreshStarsUseCase(
                viewModel,
                persistenceService
                );

            IRefreshSoftCurrencyUseCase refreshSoftCurrencyUseCase = new RefreshSoftCurrencyUseCase(
                viewModel,
                persistenceService
                );

            IRefreshCarUseCase refreshCarUseCase = new RefreshCarUseCase(
                persistenceService,
                carViewer3DInteractor,
                configurationService.CarLibrary
                );

            useCases = new MainMenuUIUseCases(
                setStarsUseCase,
                refreshSoftCurrencyUseCase,
                refreshCarUseCase
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
            carViewer3DInstaller.Uninstall();

            controller.Unsubscribe();
            interactor.Unsubscribe();

            uiViewStackService.Unregister(view);
        }
    }
}
