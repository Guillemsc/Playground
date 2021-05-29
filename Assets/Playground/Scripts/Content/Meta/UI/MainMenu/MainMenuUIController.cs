using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Stage.VisualLogic.UI.MainMenu
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

        }
    }
}
