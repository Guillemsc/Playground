using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    [RequireComponent(typeof(ActionInputDetectionUIView))]
    public class ActionInputDetectionUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private ActionInputDetectionUIViewModel viewModel;
        private ActionInputDetectionUIView view;
        private ActionInputDetectionUIUseCases useCases;
        private ActionInputDetectionUIController controller;
        private ActionInputDetectionUIInteractor interactor;

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
            viewModel = new ActionInputDetectionUIViewModel();
        }

        private void GenerateUseCases()
        {
            useCases = new ActionInputDetectionUIUseCases(
                );
        }

        private void Install()
        {
            view = GetComponent<ActionInputDetectionUIView>();

            controller = new ActionInputDetectionUIController(viewModel, useCases);
            interactor = new ActionInputDetectionUIInteractor(viewModel, useCases);

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
