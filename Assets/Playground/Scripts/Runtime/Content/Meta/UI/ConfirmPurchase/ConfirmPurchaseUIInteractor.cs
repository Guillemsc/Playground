using Juce.CoreUnity.UI;
using System;
using UnityEngine;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class ConfirmPurchaseUIInteractor : UIInteractor
    {
        private readonly ConfirmPurchaseUIViewModel viewModel;
        private readonly ConfirmPurchaseUIUseCases useCases;
        private readonly EventsData eventsData;

        public event Action OnPurchased;

        public ConfirmPurchaseUIInteractor(
            ConfirmPurchaseUIViewModel viewModel,
            ConfirmPurchaseUIUseCases useCases,
            EventsData eventsData
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
            this.eventsData = eventsData;
        }

        public void Refresh()
        {
        
        }

        public void Subscribe()
        {
            eventsData.OnPurchased += OnPurchasedEvent;
        }

        public void Unsubscribe()
        {
            eventsData.OnPurchased -= OnPurchasedEvent;
        }

        public void Setup(int price, Sprite icon)
        {
            useCases.SetupDataUseCase.Execute(price, icon);
        }

        private void OnPurchasedEvent()
        {
            OnPurchased?.Invoke();
        }
    }
}
