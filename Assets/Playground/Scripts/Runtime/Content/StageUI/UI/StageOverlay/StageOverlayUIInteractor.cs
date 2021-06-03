using Juce.CoreUnity.UI;
using System;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIInteractor : UIInteractor
    {
        private readonly StageOverlayUIViewModel viewModel;
        private readonly StageOverlayUIUseCases useCases;

        public StageOverlayUIInteractor(
            StageOverlayUIViewModel viewModel,
            StageOverlayUIUseCases useCases
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
            viewModel.RegisteredRestartCallbacks = null;
        }

        public void RegisterRestartCallback(Action callback)
        {
            viewModel.RegisteredRestartCallbacks += callback;
        }

        public void SetTimerTime(TimeSpan timeSpan)
        {
            useCases.SetTimerTimeUseCase.Execute(timeSpan);
        }
    }
}
