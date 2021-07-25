using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class ConfirmPurchaseUIController
    {
        private readonly ConfirmPurchaseUIViewModel viewModel;
        private readonly ConfirmPurchaseUIUseCases useCases;

        public ConfirmPurchaseUIController(
            ConfirmPurchaseUIViewModel viewModel,
            ConfirmPurchaseUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnClosePanelClickedEvent.OnExecute += OnClosePanelClickedEvent;
            viewModel.OnConfirmationClickedEvent.OnExecute += OnConfirmationClickedEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnClosePanelClickedEvent.OnExecute -= OnClosePanelClickedEvent;
            viewModel.OnConfirmationClickedEvent.OnExecute -= OnConfirmationClickedEvent;
        }

        private void OnClosePanelClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            uiViewStackService.New().Hide<ConfirmPurchaseUIView>(instantly: false).Execute();
        }

        private void OnConfirmationClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            useCases.PurchasedUseCase.Execute();
        }
    }
}
