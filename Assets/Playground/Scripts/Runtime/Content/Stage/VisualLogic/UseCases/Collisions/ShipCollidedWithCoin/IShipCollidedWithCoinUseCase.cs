using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithCoin
{
    public interface IShipCollidedWithCoinUseCase
    {
        void Execute(CoinEntityView coinEntityView);
    }
}
