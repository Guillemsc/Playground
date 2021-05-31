using Juce.CoreUnity.Service;
using Playground.Content.StageUI.UI.StageSettings.UseCases;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.StageSettings
{
    [RequireComponent(typeof(StageSettingsUIView))]
    public class StageSettingsUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private StageSettingsUIViewModel viewModel;
        private StageSettingsUIView view;
        private StageSettingsUIUseCases useCases;
        private StageSettingsUIController controller;
        private StageSettingsUIInteractor interactor;

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
        }

        private void GenerateDependences()
        {
            viewModel = new StageSettingsUIViewModel();
        }

        private void GenerateUseCases()
        {
            IClosePanelSelectedUseCase closePanelSelectedUseCase = new ClosePanelSelectedUseCase(
                uiViewStackService
                );

            IExitStageSelectedUseCase exitStageSelectedUseCase = new ExitStageSelectedUseCase(
                viewModel
                );

            useCases = new StageSettingsUIUseCases(
                closePanelSelectedUseCase,
                exitStageSelectedUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<StageSettingsUIView>();

            controller = new StageSettingsUIController(viewModel, useCases);
            interactor = new StageSettingsUIInteractor(viewModel, useCases);

            view.Init(viewModel);

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
