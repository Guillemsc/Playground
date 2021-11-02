using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.State;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithCoin
{
    public class ShipCollidedWithCoinUseCase : IShipCollidedWithCoinUseCase
    {
        private readonly IEventDispatcher eventDispatcher;

        public ShipCollidedWithCoinUseCase(
            IEventDispatcher eventDispatcher
            )
        {
            this.eventDispatcher = eventDispatcher;
        }

        public void Execute(CoinEntityView coinEntityView)
        {
            coinEntityView.Despawn();

            eventDispatcher.Dispatch(ShipCollidedWithCoinInEvent.Instance);
        }
    }
}
