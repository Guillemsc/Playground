using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    [RequireComponent(typeof(StageCompletedUIView))]
    public class StageCompletedUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private StageCompletedUIViewModel viewModel;
        private StageCompletedUIView view;
        private StageCompletedUIUseCases useCases;
        private StageCompletedUIController controller;
        private StageCompletedUIInteractor interactor;

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
            viewModel = new StageCompletedUIViewModel();
        }

        private void GenerateUseCases()
        {
            PlayAgainUseCase playAgainUseCase = new PlayAgainUseCase(
                viewModel
                );

            useCases = new StageCompletedUIUseCases(
                playAgainUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<StageCompletedUIView>();

            controller = new StageCompletedUIController(viewModel, useCases);
            interactor = new StageCompletedUIInteractor(viewModel, useCases);

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
