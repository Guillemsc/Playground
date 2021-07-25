using Juce.CoreUnity.UI;
using UnityEngine;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class ConfirmPurchaseUIInteractor : UIInteractor
    {
        private readonly ConfirmPurchaseUIViewModel viewModel;
        private readonly ConfirmPurchaseUIUseCases useCases;

        public ConfirmPurchaseUIInteractor(
            ConfirmPurchaseUIViewModel viewModel,
            ConfirmPurchaseUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Refresh()
        {
        
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }

        public void Setup(int price, Sprite icon)
        {
            useCases.SetupDataUseCase.Execute(price, icon);
        }
    }
}
