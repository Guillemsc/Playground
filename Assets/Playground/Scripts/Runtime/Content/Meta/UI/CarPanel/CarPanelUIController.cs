using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIController
    {
        private readonly CarPanelUIViewModel viewModel;
        private readonly CarPanelUIUseCases useCases;

        public CarPanelUIController(
            CarPanelUIViewModel viewModel,
            CarPanelUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnBackClickedEvent.OnExecute += OnBackClickedEvent;
            viewModel.OnCarSelectedEvent.OnExecute += OnCarSelectedEvent;
            viewModel.OnCarPurchasedEvent.OnExecute += OnCarPurchasedEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnBackClickedEvent.OnExecute -= OnBackClickedEvent;
            viewModel.OnCarSelectedEvent.OnExecute -= OnCarSelectedEvent;
            viewModel.OnCarPurchasedEvent.OnExecute -= OnCarPurchasedEvent;
        }

        private void OnBackClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            uiViewStackService.New().ShowLast(instantly: false).Hide<CarPanelUIView>(instantly: true).Execute();
        }

        private void OnCarSelectedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            useCases.SelectCarUseCase.Execute();
        }

        private void OnCarPurchasedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            useCases.PurchaseCaseUseCase.Execute();
        }
    }
}
