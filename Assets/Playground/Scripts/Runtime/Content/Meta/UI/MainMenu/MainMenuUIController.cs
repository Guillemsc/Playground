using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Content.Meta.UI.CarsLibrary;
using Playground.Content.Meta.UI.DemoStages;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIController 
    {
        private readonly MainMenuUIViewModel viewModel;
        private readonly MainMenuUIUseCases useCases;

        public MainMenuUIController(
            MainMenuUIViewModel viewModel,
            MainMenuUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnCarLibraryClickedEvent.OnExecute += OnCarLibraryClickedEvent;
            viewModel.OnDemoStagesClickedEvent.OnExecute += OnDemoStagesClickedEvent;

            useCases.Show3DCarUseCase.Execute();
        }

        public void Unsubscribe()
        {
            viewModel.OnCarLibraryClickedEvent.OnExecute -= OnCarLibraryClickedEvent;
            viewModel.OnDemoStagesClickedEvent.OnExecute -= OnDemoStagesClickedEvent;
        }

        private void OnCarLibraryClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            uiViewStackService.New().Show<CarsLibraryUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }

        private void OnDemoStagesClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            uiViewStackService.New().Show<DemoStagesUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }
    }
}
