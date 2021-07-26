using UnityEngine;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class SetupDataUseCase : ISetupDataUseCase
    {
        private readonly ConfirmPurchaseUIViewModel confirmPurchaseUIViewModel;

        public SetupDataUseCase(
            ConfirmPurchaseUIViewModel confirmPurchaseUIViewModel
            )
        {
            this.confirmPurchaseUIViewModel = confirmPurchaseUIViewModel;
        }

        public void Execute(
            int price, 
            Sprite icon
            )
        {
            confirmPurchaseUIViewModel.PriceVariable.Value = price;
            confirmPurchaseUIViewModel.IconVariable.Value = icon;
        }
    }
}
