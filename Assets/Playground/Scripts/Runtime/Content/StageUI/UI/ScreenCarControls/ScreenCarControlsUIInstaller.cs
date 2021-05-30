using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ScreenCarControls
{
    [RequireComponent(typeof(ScreenCarControlsUIView))]
    public class ScreenCarControlsUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private ScreenCarControlsUIViewModel viewModel;
        private ScreenCarControlsUIView view;
        private ScreenCarControlsUIUseCases useCases;
        private ScreenCarControlsUIController controller;
        private ScreenCarControlsUIInteractor interactor;

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
    
        }

        private void GenerateUseCases()
        {
            useCases = new ScreenCarControlsUIUseCases(
                );
        }

        private void Install()
        {
            view = GetComponent<ScreenCarControlsUIView>();

            controller = new ScreenCarControlsUIController(viewModel, useCases);
            interactor = new ScreenCarControlsUIInteractor(viewModel, useCases);

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
