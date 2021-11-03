using Playground.Content.StageUI.UI.Coins;

namespace Playground.Content.Stage.VisualLogic.UseCases.CoinsChanged
{
    public class CoinsChangedUseCase : ICoinsChangedUseCase
    {
        private readonly ICoinsUIInteractor coinsUIInteractor;

        public CoinsChangedUseCase(
            ICoinsUIInteractor coinsUIInteractor
            )
        {
            this.coinsUIInteractor = coinsUIInteractor;
        }

        public void Execute(int currentPoints)
        {
            coinsUIInteractor.SetCoins(currentPoints);
        }
    }
}
