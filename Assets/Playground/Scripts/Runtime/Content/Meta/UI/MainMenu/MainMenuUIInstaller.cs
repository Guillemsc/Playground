using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
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
            viewModel = new MainMenuUIViewModel();
        }

        private void Install()
        {
            view = GetComponent<MainMenuUIView>();

            useCases = new MainMenuUIUseCases();

            controller = new MainMenuUIController(viewModel, useCases);
            interactor = new MainMenuUIInteractor(viewModel, useCases);

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
