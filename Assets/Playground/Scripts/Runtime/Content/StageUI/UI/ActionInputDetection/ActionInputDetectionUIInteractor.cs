using Juce.Core.Events.Generic;
using Juce.Core.Subscribables;
using System;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public class ActionInputDetectionUIInteractor : IActionInputDetectionUIInteractor, ISubscribable
    {
        private readonly ActionInputDetectionUIViewModel viewModel;
        private readonly ActionInputDetectionUIEvents events;

        public event GenericEvent<ActionInputDetectionUIInteractor, EventArgs> InputActionReceived;

        public ActionInputDetectionUIInteractor(
            ActionInputDetectionUIViewModel viewModel,
            ActionInputDetectionUIEvents events
            )
        {
            this.viewModel = viewModel;
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
