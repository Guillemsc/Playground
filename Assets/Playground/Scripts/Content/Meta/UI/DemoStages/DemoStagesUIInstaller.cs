using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.Service;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    [RequireComponent(typeof(DemoStagesUIView))]
    public class DemoStagesUIInstaller : MonoBehaviour
    {
        [Header("Dependences")]
        [SerializeField] private Transform demoStageButtonUIEntriesParent = default;
        [SerializeField] private DemoStageButtonUIEntry demoStageButtonUIEntryPrefab = default;

        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;

        private DemoStageButtonUIEntryFactory demoStageButtonUIEntryFactory;
        private DemoStageButtonUIEntryRepository demoStageButtonUIEntryRepository;

        private DemoStagesUIViewModel viewModel;
        private DemoStagesUIView view;
        private DemoStagesUIUseCases useCases;
        private DemoStagesUIController controller;
        private DemoStagesUIInteractor interactor;

        private void Awake()
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
            Contract.IsNotNull(demoStageButtonUIEntriesParent, this);
            Contract.IsNotNull(demoStageButtonUIEntryPrefab, this);

            viewModel = new DemoStagesUIViewModel();

            demoStageButtonUIEntryFactory = new DemoStageButtonUIEntryFactory(
                demoStageButtonUIEntriesParent,
                demoStageButtonUIEntryPrefab,
                viewModel.OnDemoStageButtonClickedEvent
                );

            demoStageButtonUIEntryRepository = new DemoStageButtonUIEntryRepository();
        }

        private void GenerateUseCases()
        {
            ISpawnDemoStageUseCase spawnDemoStageUseCase = new SpawnDemoStageUseCase(
                demoStageButtonUIEntryFactory,
                demoStageButtonUIEntryRepository
                );

            ISpawnDemoStagesUseCase spawnDemoStagesUseCase = new SpawnDemoStagesUseCase(
                configurationService.DemoStagesConfiguration,
                spawnDemoStageUseCase
                );

            useCases = new DemoStagesUIUseCases(
                spawnDemoStageUseCase,
                spawnDemoStagesUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<DemoStagesUIView>();

            controller = new DemoStagesUIController(viewModel, useCases);
            interactor = new DemoStagesUIInteractor(viewModel, useCases);

            view.Init(viewModel);

            controller.Subscribe();
            interactor.Subscribe();

            uiViewStackService.Register(view);
        }

        private void Uninstall()
        {
            controller.Unsubscribe();
            interactor.Unsubscribe();

            uiViewStackService.Unregister(view);
        }
    }
}
