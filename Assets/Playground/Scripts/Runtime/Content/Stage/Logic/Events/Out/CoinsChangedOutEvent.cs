namespace Playground.Content.Stage.Logic.Events
{
    public class CoinsChangedOutEvent
    {
        public int CurrentCoins { get; }

        public CoinsChangedOutEvent(
            int currentCoins
            )
        {
            CurrentCoins = currentCoins;
        }
    }
}
