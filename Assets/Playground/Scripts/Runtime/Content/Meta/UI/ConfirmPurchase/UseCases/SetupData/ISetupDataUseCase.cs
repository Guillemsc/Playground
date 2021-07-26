using UnityEngine;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public interface ISetupDataUseCase
    {
        void Execute(
            int price, 
            Sprite icon
            );
    }
}
