using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.Service;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    [RequireComponent(typeof(CarsLibraryUIView))]
    public class CarsLibraryUIInstaller : MonoBehaviour
    {
        [Header("Dependences")]
        [SerializeField] private Transform carLibraryUIEntriesParent = default;
        [SerializeField] private CarLibraryUIEntry carLibraryUIEntryPrefab = default;

        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private UserService userService;

        private CarLibraryUIEntryFactory carLibraryUIEntryFactory;
        private CarLibraryUIEntryRepository carLibraryUIEntryRepository;

        private CarsLibraryUIViewModel viewModel;
        private CarsLibraryUIView view;
        private CarsLibraryUIUseCases useCases;
        private CarsLibraryUIController controller;
        private CarsLibraryUIInteractor interactor;

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
            Contract.IsNotNull(carLibraryUIEntriesParent, this);
            Contract.IsNotNull(carLibraryUIEntryPrefab, this);

            viewModel = new CarsLibraryUIViewModel();

            carLibraryUIEntryFactory = new CarLibraryUIEntryFactory(
                carLibraryUIEntriesParent,
                carLibraryUIEntryPrefab,
                viewModel.OnCarClickedEvent
                );

            carLibraryUIEntryRepository = new CarLibraryUIEntryRepository();
        }

        private void GenerateUseCases()
        {
            ISpawnCarUseCase spawnCarUseCase = new SpawnCarUseCase(
                carLibraryUIEntryFactory,
                carLibraryUIEntryRepository
                );

            ISpawnCarsUseCase spawnCarsUseCase = new SpawnCarsUseCase(
                configurationService.CarLibrary,
                spawnCarUseCase
                );

            ICarSelectedUseCase carSelectedUseCase = new CarSelectedUseCase(
                userService
                );

            useCases = new CarsLibraryUIUseCases(
                spawnCarUseCase,
                spawnCarsUseCase,
                carSelectedUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<CarsLibraryUIView>();

            controller = new CarsLibraryUIController(viewModel, useCases);
            interactor = new CarsLibraryUIInteractor(viewModel, useCases);

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
