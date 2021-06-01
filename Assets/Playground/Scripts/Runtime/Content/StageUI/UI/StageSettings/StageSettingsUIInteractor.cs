using Juce.CoreUnity.UI;
using System;

namespace Playground.Content.StageUI.UI.StageSettings
{
    public class StageSettingsUIInteractor : UIInteractor
    {
        private readonly StageSettingsUIViewModel viewModel;
        private readonly StageSettingsUIUseCases useCases;

        public StageSettingsUIInteractor(
            StageSettingsUIViewModel viewModel,
            StageSettingsUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
         
        }

        public void Unsubscribe()
        {
            viewModel.RegisteredExitStageCallbacks = null;
        }

        public void RegisterExitStageCallback(Action callback)
        {
            viewModel.RegisteredExitStageCallbacks += callback;
        }
    }
}
