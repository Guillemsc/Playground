using Juce.CoreUnity.Service;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    [RequireComponent(typeof(ActionInputDetectionUIView))]
    public class ActionInputDetectionUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private ActionInputDetectionUIViewModel viewModel;
        private ActionInputDetectionUIEvents events;
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
            events = new ActionInputDetectionUIEvents();
        }

        private void GenerateUseCases()
        {
            IInputActionReceivedUseCase inputActionReceivedUseCase = new InputActionReceivedUseCase(
                events
                );

            useCases = new ActionInputDetectionUIUseCases(
                inputActionReceivedUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<ActionInputDetectionUIView>();

            controller = new ActionInputDetectionUIController(viewModel, useCases);
            interactor = new ActionInputDetectionUIInteractor(viewModel, useCases, events);

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
