using Juce.Core.Events.Generic;
using Juce.CoreUnity.UI;
using System;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public class ActionInputDetectionUIInteractor : UIInteractor
    {
        private readonly ActionInputDetectionUIViewModel viewModel;
        private readonly ActionInputDetectionUIUseCases useCases;
        private readonly ActionInputDetectionUIEvents events;

        public event GenericEvent<ActionInputDetectionUIInteractor, EventArgs> InputActionReceived;

        public ActionInputDetectionUIInteractor(
            ActionInputDetectionUIViewModel viewModel,
            ActionInputDetectionUIUseCases useCases,
            ActionInputDetectionUIEvents events
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
            this.events = events;
        }

        public void Subscribe()
        {
            events.InputActionReceived += OnInputActionReceived;
        }

        public void Unsubscribe()
        {
            events.InputActionReceived -= OnInputActionReceived;
        }

        public void Refresh()
        {

        }

        private void OnInputActionReceived()
        {
            InputActionReceived?.Invoke(this, EventArgs.Empty);
        }
    }
}
