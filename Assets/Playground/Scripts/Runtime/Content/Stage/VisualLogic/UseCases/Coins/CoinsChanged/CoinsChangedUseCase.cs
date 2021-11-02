using Playground.Content.Stage.VisualLogic.State;

namespace Playground.Content.Stage.VisualLogic.UseCases.CoinsChanged
{
    public class CoinsChangedUseCase : ICoinsChangedUseCase
    {
        private readonly CoinsState coinsState;

        public CoinsChangedUseCase(CoinsState coinsState)
        {
            this.coinsState = coinsState;
        }

        public void Execute(int currentPoints)
        {

        }
    }
}
