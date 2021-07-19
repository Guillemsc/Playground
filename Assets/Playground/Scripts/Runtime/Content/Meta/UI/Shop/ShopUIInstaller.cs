using Juce.CoreUnity.Service;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.Shop
{
    [RequireComponent(typeof(ShopUIView))]
    public class ShopUIInstaller : MonoBehaviour
    {
        [Header("Dependences")]
        [SerializeField] private Transform shopCarUIEntriesParent = default;
        [SerializeField] private ShopCarUIEntry shopCarUIEntryPrefab = default;

        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private PersistenceService userService;

        private ShopCarUIEntryFactory shopCarUIEntryFactory;
        private ShopCarUIEntryRepository shopCarUIEntryRepository;

        private ShopUIViewModel viewModel;
        private ShopUIView view;
        private ShopUIUseCases useCases;
        private ShopUIController controller;
        private ShopUIInteractor interactor;

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
            userService = ServicesProvider.GetService<PersistenceService>();
        }

        private void GenerateDependences()
        {
            viewModel = new ShopUIViewModel();

            shopCarUIEntryFactory = new ShopCarUIEntryFactory(
                shopCarUIEntriesParent,
                shopCarUIEntryPrefab,
                viewModel.OnShopCarClickedEvent
                );

            shopCarUIEntryRepository = new ShopCarUIEntryRepository();
        }

        private void GenerateUseCases()
        {
            ISpawnCarUseCase spawnCarUseCase = new SpawnCarUseCase(
                shopCarUIEntryFactory,
                shopCarUIEntryRepository
                );

            ISpawnCarsUseCase spawnCarsUseCase = new SpawnCarsUseCase(
                configurationService.CarLibrary,
                spawnCarUseCase
                );

            useCases = new ShopUIUseCases(
                spawnCarUseCase,
                spawnCarsUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<ShopUIView>();

            controller = new ShopUIController(viewModel, useCases);
            interactor = new ShopUIInteractor(viewModel, useCases);

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
