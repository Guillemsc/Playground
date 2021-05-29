using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStagesUIController
    {
        private readonly DemoStagesUIViewModel viewModel;
        private readonly DemoStagesUIUseCases useCases;

        public DemoStagesUIController(
            DemoStagesUIViewModel viewModel,
            DemoStagesUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            useCases.SpawnDemoStagesUseCase.Execute();
        }

        public void Unsubscribe()
        {
          
        }
    }
}
