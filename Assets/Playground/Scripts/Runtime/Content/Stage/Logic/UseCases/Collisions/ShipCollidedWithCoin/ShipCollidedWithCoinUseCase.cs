using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases.ShipCollidedWithCoin
{
    public class ShipCollidedWithCoinUseCase : IShipCollidedWithCoinUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly StageState stageState;

        public ShipCollidedWithCoinUseCase(
            IEventDispatcher eventDispatcher,
            StageState stageState
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.stageState = stageState;
        }

        public void Execute()
        {
            stageState.CurrentCoins += 1;

            eventDispatcher.Dispatch(new CoinsChangedOutEvent(stageState.CurrentCoins));
        }
    }
}
