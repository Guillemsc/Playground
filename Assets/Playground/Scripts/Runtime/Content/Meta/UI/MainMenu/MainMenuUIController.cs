using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Content.Meta.UI.CarsLibrary;
using Playground.Content.Meta.UI.Credits;
using Playground.Content.Meta.UI.DemoStages;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIController 
    {
        private readonly MainMenuUIViewModel viewModel;
        private readonly MainMenuUIUseCases useCases;
        private readonly UIViewStackService uiViewStackService;

        public MainMenuUIController(
            MainMenuUIViewModel viewModel,
            MainMenuUIUseCases useCases,
            UIViewStackService uiViewStackService
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
            this.uiViewStackService = uiViewStackService;
        }

        public void Subscribe()
        {
            viewModel.OnCarLibraryClickedEvent.OnExecute += OnCarLibraryClickedEvent;
            viewModel.OnDemoStagesClickedEvent.OnExecute += OnDemoStagesClickedEvent;
            viewModel.OnCreditsClickedEvent.OnExecute += OnCreditsClickedEvent;

            useCases.Show3DCarUseCase.Execute();
        }

        public void Unsubscribe()
        {
            viewModel.OnCarLibraryClickedEvent.OnExecute -= OnCarLibraryClickedEvent;
            viewModel.OnDemoStagesClickedEvent.OnExecute -= OnDemoStagesClickedEvent;
            viewModel.OnCreditsClickedEvent.OnExecute -= OnCreditsClickedEvent;
        }

        private void OnCarLibraryClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().Show<CarsLibraryUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }

        private void OnDemoStagesClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().Show<DemoStagesUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }

        private void OnCreditsClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().Show<CreditsUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }
    }
}
