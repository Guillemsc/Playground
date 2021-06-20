using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.Credits
{
    [RequireComponent(typeof(CreditsUIView))]
    public class CreditsUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private CreditsUIViewModel viewModel;
        private CreditsUIView view;
        private CreditsUIController controller;
        private CreditsUIInteractor interactor;

        private void Start()
        {
            GatherDependences();
            GenerateDependences();

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
            viewModel = new CreditsUIViewModel();
        }

        private void Install()
        {
            view = GetComponent<CreditsUIView>();

            controller = new CreditsUIController(
                viewModel,
                uiViewStackService
                );

            interactor = new CreditsUIInteractor(viewModel);

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
