using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.Shop
{
    public class ShopUIController
    {
        private readonly ShopUIViewModel viewModel;
        private readonly ShopUIUseCases useCases;

        public ShopUIController(
            ShopUIViewModel viewModel,
            ShopUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnBackClickedEvent.OnExecute += OnBackClickedEvent;
            viewModel.OnShopCarClickedEvent.OnExecute += OnShopCarClickedEvent;

            useCases.SpawnCarsUseCase.Execute();
        }

        public void Unsubscribe()
        {
            viewModel.OnBackClickedEvent.OnExecute -= OnBackClickedEvent;
        }

        private void OnBackClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            uiViewStackService.New().ShowLast(instantly: false).Hide<ShopUIView>(instantly: true).Execute();
        }

        private void OnShopCarClickedEvent(ShopCarUIEntry shopCarUIEntry, PointerCallbacks pointerCallbacks)
        {
            useCases.CarSelectedUseCase.Execute(shopCarUIEntry.CarTypeId);
        }
    }
}
