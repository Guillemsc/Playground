using Juce.CoreUnity.PointerCallback;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.Credits
{
    public class CreditsUIController
    {
        private readonly CreditsUIViewModel viewModel;
        private readonly UIViewStackService uiViewStackService;

        public CreditsUIController(
            CreditsUIViewModel viewModel,
            UIViewStackService uiViewStackService
            )
        {
            this.viewModel = viewModel;
            this.uiViewStackService = uiViewStackService;
        }

        public void Subscribe()
        {
            viewModel.OnScreenClickedEvent.OnExecute += OnScreenClickedEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnScreenClickedEvent.OnExecute -= OnScreenClickedEvent;
        }

        private void OnScreenClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().ShowLastAsForeground(instantly: true).Hide<CreditsUIView>(instantly: false).Execute();
        }
    }
}
