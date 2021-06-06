using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
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
            viewModel.OnDemoStagesClicked += OnDemoStagesClicked;
        }

        public void Unsubscribe()
        {
            viewModel.OnDemoStagesClicked -= OnDemoStagesClicked;
        }

        private void OnDemoStagesClicked(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            uiViewStackService.New().Show<DemoStagesUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }
    }
}
