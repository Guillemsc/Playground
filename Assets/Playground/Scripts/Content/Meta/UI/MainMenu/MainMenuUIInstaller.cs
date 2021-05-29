using Juce.CoreUnity.Service;
using Playground.Utils.UIViewStack;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UI.MainMenu
{
    [RequireComponent(typeof(MainMenuUIView))]
    public class MainMenuUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private MainMenuUIViewModel viewModel;
        private MainMenuUIView view;
        private MainMenuUIUseCases useCases;
        private MainMenuUIController controller;
        private MainMenuUIInteractor interactor;

        private void Awake()
        {
            GatherDependences();

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

        private void Install()
        {
            viewModel = new MainMenuUIViewModel();

            view = GetComponent<MainMenuUIView>();

            useCases = new MainMenuUIUseCases();

            controller = new MainMenuUIController(viewModel, useCases);
            interactor = new MainMenuUIInteractor(viewModel, useCases);

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
